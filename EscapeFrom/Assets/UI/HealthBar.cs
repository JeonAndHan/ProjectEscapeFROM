using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    protected Image mBar;
    [SerializeField]
    protected TextMeshProUGUI mValueText;

    public void ShowGauge(float current, float max)
    {
        mBar.fillAmount = current / max;
        mValueText.text = string.Format("{0}/{1}",
            current.ToString("NO"), max.ToString("NO"));
        //mValueText.text = mBar.fillAmount.ToString("PO");
    }
}
