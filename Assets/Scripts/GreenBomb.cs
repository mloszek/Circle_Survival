using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBomb : AbstractBomb
{
    [SerializeField]
    private BombImageProgress imageProgress;

    public override void Press()
    {
        base.Press();
        SoundsController.Get().PlayHide();
        StopCoroutine(countdownCoroutine);
        countdownCoroutine = null;
        animator.SetTrigger(KeysHolder.ANIM_HIDE_TRIGGER);
        Destroy(gameObject, KeysHolder.ANIM_TIME);
    }

    protected override IEnumerator Countdown()
    {
        while (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            imageProgress.SetFillBarRate(1 - (lifeTime / wholeLifeTime));
            yield return null;
        }

        Detonate();
    }
}
