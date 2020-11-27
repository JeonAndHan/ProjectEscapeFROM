﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    [Header("TextTriggerScript")]
    //public TextTrigger m_TextTrigger;
    public TextTrigger m_Room1_Board_Text;
    public TextTrigger m_Room2_Board_Text;
    public TextTrigger m_Computer_Text;
    public TextTrigger m_Desk_Text;
    public TextTrigger m_Safe_Text;
    public TextTrigger m_Room1PW_Text;

    [Header("TextTriggerUI")]
    public GameObject m_Room1_Board_UI;
    public GameObject m_Room2_Board_UI;
    public GameObject m_Desk_UI;
    public GameObject m_safe_UI;
    public GameObject m_Room1PW_UI;
    public TextMeshProUGUI m_Investigate_Text;
    public TextMeshProUGUI m_acquire_Text;
    public Canvas m_canvas;


    [Header("TimeAttack")]
    public GameObject m_TimeAttack_UI;
    public TextMeshProUGUI m_Time_Text;
    private float time;

    [Header("TextTriggerBool")]
    private bool m_computer_investigate;
    private bool m_Room1_Board_investigate;
    private bool m_Room2_Board_investigate;
    private bool m_Desk_investigate;
    private bool m_Safe_investigate;
    private bool m_Room1PW_investigate;

    [Header("KeyBoardBool")]
    public bool m_pressR;
    public bool m_pressZ;

    public keyPadCtrl m_keypad;
    public Room1Pw m_room1_pw;

    [Header("Weapon")]
    public GameObject m_player_weapon;
    public GameObject m_safe_weapon;

    // Start is called before the first frame update
    void Start()
    {
        time = 300f;
    }

    // Update is called once per frame
    void Update()
    {

        investigate_TextTrigger();

        if(m_keypad.m_right && m_Safe_Text.m_textTrigger)
        {
            m_acquire_Text.gameObject.SetActive(true);
        }
        else
        {
            m_acquire_Text.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_pressZ = true;
            Debug.Log("press Z");
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            m_pressZ = false;
            Debug.Log("z에서 손 뗌");
        }

        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy) // z가 눌렸고, acquiretext가 true라면
        {
            m_safe_weapon.gameObject.SetActive(false);
            m_player_weapon.gameObject.SetActive(true);
        }

        if (m_player_weapon.gameObject.activeInHierarchy)
        {
            m_acquire_Text.gameObject.SetActive(false);
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

        if (m_pressR && m_Safe_investigate && !m_keypad.m_right) //R버튼이 눌리고 safe 트리거에 들어가있고 비번을 맞추지 못했다면
        {
            m_safe_UI.SetActive(true);
        }
        else
        {
            m_safe_UI.SetActive(false);
        }

        if (m_pressR && m_Room1PW_investigate && ! m_room1_pw.m_right) //R버튼이 눌리고 room1PW 트리거에 들어가있고 비번을 맞추지 못했다면
        {
            m_Room1PW_UI.SetActive(true);
        }
        else
        {
            m_Room1PW_UI.SetActive(false);
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

    public void investigate_TextTrigger()
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
        else if (m_Safe_Text.m_textTrigger && !m_keypad.m_right)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Safe_investigate = true;
        }
        else if(m_Room1PW_Text.m_textTrigger && !m_room1_pw.m_right)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Room1PW_investigate = true;
        }
        else
        {
            m_Investigate_Text.gameObject.SetActive(false);
            m_computer_investigate = false;
            m_Room1_Board_investigate = false;
            m_Room2_Board_investigate = false;
            m_Desk_investigate = false;
            m_Safe_investigate = false;
            m_Room1PW_investigate = false;
        }
    }
}
