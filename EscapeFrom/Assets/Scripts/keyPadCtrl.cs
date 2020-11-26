using System.Collections;
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

    private bool m_one;
    private bool m_two;
    private bool m_three;
    private bool m_four;
    private bool m_five;
    private bool m_six;
    private bool m_seven;
    private bool m_eight;
    private bool m_nine;
    private bool m_zero;
    private bool m_green;

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
            }
        }
         
    }

    public void check_password()
    {
        //숫자 순서대로 누르게 하기..............ㅠㅠㅠ
        if (m_six) 
        {
            if (m_three) 
            {
                Debug.Log(m_count + "2,4 누름");
                if (m_four) 
                {
                    Debug.Log(m_count + "2,4,3 누름");
                    if (m_two)
                    {
                            m_right = true;  
                            Debug.Log("금고 번호 맞춤");
                        m_safe_door.transform.localEulerAngles = new Vector3(0f, -120f, 0f);
                    }
                }
            }
        }
    }

    public void ClickOne()
    {
        m_one = true;
        m_count++;
        Debug.Log("1번눌림");
    }

    public void ClickTwo()
    {
        m_two = true;
        m_count++;
        Debug.Log("2번눌림");
    }
    public void ClickThree()
    {
        m_three = true;
        m_count++;
        Debug.Log("3번눌림");
    }
    public void ClickFour()
    {
        m_four = true;
        m_count++;
        Debug.Log("4번눌림");
    }
    public void ClickFive()
    {
        m_five = true;
        m_count++;
    }
    public void ClickSix()
    {
        m_six = true;
        m_count++;
        Debug.Log("6번눌림");
    }
    public void ClickSeven()
    {
        m_seven = true;
        m_count++;
    }
    public void ClickEight()
    {
        m_eight = true;
        m_count++;
    }
    public void ClickNine()
    {
        m_nine = true;
        m_count++;
    }
    public void ClickZero()
    {
        m_zero = true;
        m_count++;
    }

    public void ClickGreen()
    {
        m_green = true;
        Debug.Log("green 눌림");
        //m_one = false;
        //m_two = false;
        //m_three = false;
        //m_four = false;
        //m_five = false;
        //m_six = false;
        //m_seven = false;
        //m_eight = false;
        //m_nine = false;
        //m_zero = false;

    }

}
