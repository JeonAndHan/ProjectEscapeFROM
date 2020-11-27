using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room2PW : MonoBehaviour
{
    public Button m_Ebtn;
    public Button m_Sbtn;
    public Button m_Cbtn;
    public Button m_Abtn;
    public Button m_Pbtn;
    public Button m_EnterBtn;

    public bool m_right = false; //비밀번호 맞았을 때 true
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickE()
    {
        Debug.Log("E 눌림");
    }

    public void ClickS()
    {
        Debug.Log("S 눌림");
    }

    public void ClickC()
    {
        Debug.Log("C 눌림");
    }

    public void ClickA()
    {
        Debug.Log("A 눌림");
    }

    public void ClickP()
    {
        Debug.Log("P 눌림");
    }

    public void ClickEnter()
    {
        Debug.Log("Enter 눌림");
    }




}
