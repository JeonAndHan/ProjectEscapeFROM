using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    protected Image m_bar;
    protected TextMeshProUGUI m_value_text;

    public void ShowHPbar(float current, float max)
    {
        
        m_bar.fillAmount = current / max;
        m_value_text = string.Format("{0}/{1}", m_currentHP.ToString("N0"), m_maxHP.ToString("N0"));
       
    }
}
