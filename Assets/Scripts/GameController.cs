using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnPositions;
    [SerializeField]
    private GameObject spawnPositionsParent;
    [SerializeField]
    private GameObject greenBomb;
    [SerializeField]
    private GameObject blackBomb;
    [SerializeField]
    private Text scoreText, summaryScore, gameOverText, highscoreText;
    [SerializeField]
    private Button backButton;

    private Coroutine bombSpawnerCoroutine, timerCoroutine, explosionCoroutine;

    private float timer = 0;
    private GameObject tempGameObject;
    private Transform tempTransform;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        scoreText.text = KeysHolder.DEF_SCORE_VAL;
        timer = 0;
        summaryScore.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        if (bombSpawnerCoroutine != null)
        {
            StopCoroutine(bombSpawnerCoroutine);
        }
        bombSpawnerCoroutine = StartCoroutine(SpawnBombs());

        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
        timerCoroutine = StartCoroutine(Timer());
    }

    private void GenerateBomb()
    {
        tempTransform = GetRandomPosition();
        if (Random.Range(0, 50) < 5)
            tempGameObject = Instantiate(blackBomb, tempTransform.position, Quaternion.identity, tempTransform);
        else
            tempGameObject = Instantiate(greenBomb, tempTransform.position, Quaternion.identity, tempTransform);

        tempGameObject.GetComponent<AbstractBomb>().SubscribeGameController(this);
        tempGameObject.GetComponent<AbstractBomb>().SetTimer(timer);
    }

    private Transform GetRandomPosition()
    {
        Transform tempTransform = spawnPositions[Random.Range(0, spawnPositions.Count)];

        while (tempTransform.childCount > 0)
            tempTransform = spawnPositions[Random.Range(0, spawnPositions.Count)];

        return tempTransform;
    }

    public void StopGame()
    {
        StopCoroutine(bombSpawnerCoroutine);
        StopCoroutine(timerCoroutine);

        if (explosionCoroutine != null)
        {
            StopCoroutine(explosionCoroutine);
        }
        explosionCoroutine = StartCoroutine(DoDestroy());

        spawnPositionsParent.SetActive(false);
        scoreText.gameObject.SetActive(false);
        summaryScore.gameObject.SetActive(true);
        summaryScore.text = ((int)timer).ToString();
        gameOverText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);

        if (PlayerPrefs.HasKey(KeysHolder.SAVE_HIGHSCORE))
        {
            if (timer > PlayerPrefs.GetInt((KeysHolder.SAVE_HIGHSCORE)))
            {
                PlayerPrefs.SetInt(KeysHolder.SAVE_HIGHSCORE, (int)timer);
                highscoreText.gameObject.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt(KeysHolder.SAVE_HIGHSCORE, (int)timer);
            highscoreText.gameObject.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(KeysHolder.MENU_SCENE);
    }

    private IEnumerator SpawnBombs()
    {
        while (true)
        {
            GenerateBomb();

            yield return new WaitForSecondsRealtime(IntervalsHolder.GetSpawnInterval(timer));

        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            timer += Time.deltaTime;
            scoreText.text = ((int)timer).ToString();

            yield return new WaitForSecondsRealtime(0);
        }
    }

    private IEnumerator DoDestroy()
    {
        yield return new WaitForSeconds(KeysHolder.ANIM_TIME);
    }
}
