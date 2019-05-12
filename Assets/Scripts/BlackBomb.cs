using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBomb : AbstractBomb
{
    public override void Press()
    {
        base.Press();
        Detonate();
    }

    protected override IEnumerator Countdown()
    {
        while (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            yield return null;
        }

        SoundsController.Get().PlayHide();
        Destroy(gameObject, KeysHolder.ANIM_TIME);
        animator.SetTrigger(KeysHolder.ANIM_HIDE_TRIGGER);
    }
}
