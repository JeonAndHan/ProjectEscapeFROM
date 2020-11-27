﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPadCtrl : MonoBehaviour
{
    //safe keypad Ctrl
    public Button m_num1;
    public Button m_num2;
    public Button m_num3;
    public Button m_num4;
    public Button m_num5;
    public Button m_num6;
    public Button m_num7;
    public Button m_num8;
    public Button m_num9;
    public Button m_num0;
    public Button m_Green;

    private string[] m_clicked = new string[4];

    private bool m_green = false;
    
    private int m_count = 0; //4번 입력받고 더이상 못받게 count
    public bool m_right = false; //비밀번호 맞았을 때 true
    public GameObject m_safe_door;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (m_green)
        {
            if(m_count == 4)
            {
                check_password();
            }
            else
            {
                m_count = 0;
                m_clicked = new string[4];//배열초기화
            }
        }
         
    }

    public void check_password()
    {
        //숫자 순서대로 누르게 하기..............ㅠㅠㅠ
        if(m_clicked[0]=="2" && m_clicked[1]=="4" && m_clicked[2]=="3" && m_clicked[3] == "6")
        {
            Debug.Log("금고 번호 맞춤");
            m_safe_door.transform.localEulerAngles = new Vector3(0f, -120f, 0f);

        }
    }

    public void ClickOne()
    {
        m_clicked[m_count] = "1";
        m_count++;
        Debug.Log("1번눌림");
    }

    public void ClickTwo()
    {
        m_clicked[m_count] = "2";
        m_count++;
        Debug.Log("2번눌림");
    }
    public void ClickThree()
    {
        m_clicked[m_count] = "3";
        m_count++;
        Debug.Log("3번눌림");
    }
    public void ClickFour()
    {
        m_clicked[m_count] = "4";
        m_count++;
        Debug.Log("4번눌림");
    }
    public void ClickFive()
    {
        m_clicked[m_count] = "5";
        m_count++;
    }
    public void ClickSix()
    {
        m_clicked[m_count] = "6";
        m_count++;
        Debug.Log("6번눌림");
    }
    public void ClickSeven()
    {
        m_clicked[m_count] = "7";
        m_count++;
    }
    public void ClickEight()
    {
        m_clicked[m_count] = "8";
        m_count++;
    }
    public void ClickNine()
    {
        m_clicked[m_count] = "9";
        m_count++;
    }
    public void ClickZero()
    {
        m_clicked[m_count] = "0";
        m_count++;
    }

    public void ClickGreen()
    {
        m_green = true;
        Debug.Log("green 눌림");

    }

}
