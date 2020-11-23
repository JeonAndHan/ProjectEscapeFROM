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
    public TextMeshProUGUI m_Investigate_Text;

    public GameObject m_Room1_Board_UI;
    public GameObject m_Room2_Board_UI;
    public GameObject m_Desk_UI;

    public GameObject m_TimeAttack_UI;
    public TextMeshProUGUI m_Time_Text;

    private bool m_computer_investigate;
    private bool m_Room1_Board_investigate;
    private bool m_Room2_Board_investigate;
    private bool m_Desk_investigate;
    private bool m_Safe_investigate;
    private bool m_pressR;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Room1_Board_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Room1_Board_investigate = true;
        }
        else if (m_Room2_Board_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Room2_Board_investigate = true;
        }
        else if (m_Computer_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_computer_investigate = true;
        }
        else if (m_Desk_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Desk_investigate = true;
        }
        else if (m_Safe_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Safe_investigate = true;
        }
        else
        {
            m_Investigate_Text.gameObject.SetActive(false);
            m_computer_investigate = false;
            m_Room1_Board_investigate = false;
            m_Room2_Board_investigate = false;
            m_Desk_investigate = false;
            m_Safe_investigate = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            m_pressR = true;
            Debug.Log("press R");
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            m_pressR = false;
            Debug.Log("R에서 손뗌");
        }

        if(m_pressR && m_Room1_Board_investigate) // R버튼이 눌리고 room1의 트리거에 들어가 있다면
        {
            m_Room1_Board_UI.SetActive(true);
        }
        else
        {
            m_Room1_Board_UI.SetActive(false);
        }

        if (m_pressR && m_Room2_Board_investigate) // R버튼이 눌리고 room2의 트리거에 들어가 있다면
        {
            m_Room2_Board_UI.SetActive(true);
        }
        else
        {
            m_Room2_Board_UI.SetActive(false);
        }

        if (m_pressR && m_Desk_investigate) // R버튼이 눌리고 Desk의 트리거에 들어가 있다면
        {
            m_Desk_UI.SetActive(true);
        }
        else
        {
            m_Desk_UI.SetActive(false);
        }

        int i, j;

        //timeAttack
        if(time > 0)
        {
            time -= Time.deltaTime;
            i = (int)(time / 60);
            j = (int)(time % 60);
            m_Time_Text.text = i + " : " + j.ToString();
        }
        

    }
}
