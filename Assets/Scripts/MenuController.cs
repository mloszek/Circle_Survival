using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreHolder;
    [SerializeField]
    private Text scoreText;

    private void Start()
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        if (PlayerPrefs.HasKey(KeysHolder.SAVE_HIGHSCORE))
            scoreText.text = PlayerPrefs.GetInt(KeysHolder.SAVE_HIGHSCORE).ToString();
        else
            scoreHolder.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(KeysHolder.GAME_SCENE);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
