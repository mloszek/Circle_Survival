using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombImageProgress : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Image bgImage;

    public void SetFillBarRate(float fillRate)
    {
        fillImage.fillAmount = fillRate;
    }

    public void ActivateBadge(bool isOn)
    {
        if (fillImage && fillImage.transform.parent)
            fillImage.transform.parent.gameObject.SetActive(isOn);
    }
}
