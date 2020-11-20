using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    //public TextTrigger m_TextTrigger;
    public TextTrigger m_Room1_Board_Text;
    public TextTrigger m_Room2_Board_Text;
    public TextTrigger m_Computer_Text;
    public TextTrigger m_Desk_Text;
    public TextTrigger m_Safe_Text;
    public Canvas m_canvas;
    public TextMeshProUGUI m_Room1_safe_Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Room1_Board_Text.m_textTrigger)
        {
            m_Room1_safe_Text.gameObject.SetActive(true);
        }
        else if (m_Room2_Board_Text.m_textTrigger)
        {
            m_Room1_safe_Text.gameObject.SetActive(true);
        }
        else if (m_Computer_Text.m_textTrigger)
        {
            m_Room1_safe_Text.gameObject.SetActive(true);
        }
        else if (m_Desk_Text.m_textTrigger)
        {
            m_Room1_safe_Text.gameObject.SetActive(true);
        }
        else if (m_Safe_Text.m_textTrigger)
        {
            m_Room1_safe_Text.gameObject.SetActive(true);
        }
        else
        {
            m_Room1_safe_Text.gameObject.SetActive(false);
        }

    }
}
