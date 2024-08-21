using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Image hpGauge;

    public void UpdateHpGauge(float fillAmount)
    {
        this.hpGauge.fillAmount = fillAmount;
    }
}