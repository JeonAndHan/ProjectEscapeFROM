using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    public TextTrigger m_TextTrigger;
    public Canvas m_canvas;
    public TextMeshProUGUI m_Room1_safe_Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TextTrigger.m_textTrigger)
        {
            m_Room1_safe_Text.gameObject.SetActive(true);
        }
        else
        {
            m_Room1_safe_Text.gameObject.SetActive(false);
        }
    }
}
