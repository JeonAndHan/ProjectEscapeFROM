﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    public static UICtrl Instance;

    [SerializeField]
    private HealthBar m_playerHpBar;
    [SerializeField]
    private GameObject m_Inventory;
    public Button m_help_bth;
    public Button m_close_btn;
    public GameObject m_manipulation_UI;

    private bool m_press_btn = true;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void showHp(float current,float max)
    {
        m_playerHpBar.ShowHPbar(current, max);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_press_btn)
        {
            m_manipulation_UI.SetActive(true);
        }
        else
        {
            m_manipulation_UI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (m_Inventory.activeInHierarchy)
            {
                m_Inventory.SetActive(false);
            }
            else
            {
                m_Inventory.SetActive(true);
            }
        }
    }

    public void pressHelp()
    {
        m_press_btn = true;
    }

    public void pressClose()
    {
        m_press_btn = false;
    }
}
