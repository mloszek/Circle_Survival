using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractBomb : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Button button;

    protected GameController gameController;
    protected float lifeTime;
    protected Coroutine countdownCoroutine;
    protected float wholeLifeTime; //for bar filling

    protected abstract IEnumerator Countdown();

    private void Start()
    {
        SoundsController.Get().PlayTicking();
        countdownCoroutine = StartCoroutine(Countdown());
    }

    protected void Detonate()
    {
        SoundsController.Get().PlayExplosion();
        animator.SetTrigger(KeysHolder.ANIM_DETONATE_TRIGGER);
        Destroy(gameObject, KeysHolder.ANIM_TIME);
        gameController.StopGame();
    }

    public virtual void Press()
    {
        button.enabled = false;
    }

    public void SubscribeGameController(GameController gameController)
    {
        this.gameController = gameController;
    }

    public void SetTimer(float timeFromBeginning)
    {
        lifeTime = wholeLifeTime = IntervalsHolder.GetDetonatorTime(timeFromBeginning);
    }
}
