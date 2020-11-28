﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Header("player변수")]
    [SerializeField]
    float m_speed;
    [SerializeField]
    float m_runSpeed;                    
    [SerializeField]
    Vector3 m_dir;
    private bool m_isDead = false;
    
    Rigidbody m_rigidbody;
    CapsuleCollider m_collider;
    Animator m_Anim;
    [SerializeField]
    GameObject m_handAttackArea;
    [SerializeField]
    GameObject m_weaponAttackArea;

    public GameObject m_player_weapon;

    private int m_JumpCount = 0;
    private bool m_isRun;
    private float m_weapon_Damage = 50f;
    private float m_hand_Damage = 20f;

    [Header("camera변수")]
    public Camera m_camera;
    public Transform m_cameraArm;
    public GameCtrl m_gameCtrl;
    private float m_lookSensitivity = 3f;
    private float m_cameraRotationLimit = 10f;
    private float m_currentCameraRotationX;

    [Header("playerHP변수")]
    [SerializeField]
    private float m_maxHP;
    private float m_currentHP;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<CapsuleCollider>();
        m_Anim = GetComponent<Animator>();

        m_currentHP = m_maxHP;
        UICtrl.Instance.showHp(m_currentHP, m_maxHP);
    }

    public void Hit(float damage)
    {
        if (!m_isDead)
        {
            m_currentHP -= damage;
            UICtrl.Instance.showHp(m_currentHP, m_maxHP);
            if (m_currentHP <= 0)
            {
                m_Anim.SetTrigger("DIE");
                m_isDead = true;
                StartCoroutine(gameover());
            }
        }
    }

    public void attackTarget(GameObject target)
    {
            if (m_player_weapon.activeInHierarchy) //player가 무기를 들고있다면
            {
                target.SendMessage("Hit", m_weapon_Damage);
            }
            else //player가 맨손이라면
            {
                target.SendMessage("Hit", m_hand_Damage);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isDead)
        {
            if (!m_gameCtrl.m_pressR)
            {
                character_Rotation();
                camera_Rotation();
                Move();
            }

            //GameObject.FindWithTag("hpBar").GetComponent<HealthBar>.ShowHPbar(m_currentHP, m_maxHP);

            if (Input.GetMouseButton(0) && !m_gameCtrl.m_pressR)
            {
                if (m_player_weapon.activeInHierarchy)
                {
                    m_Anim.SetBool("WEAPONATTACK", true);
                    m_Anim.SetBool("WALK", false);

                }
                else
                {
                    m_Anim.SetBool("ATTACK", true);
                    
                }

            }
            else
            {
                if (m_player_weapon.activeInHierarchy)
                {
                    m_Anim.SetBool("WEAPONATTACK", false);
                    // m_weaponAttackArea.SetActive(false);
                }
                else
                {
                    m_Anim.SetBool("ATTACK", false);
                    //m_handAttackArea.SetActive(false);
                }

            }

            if (Input.GetKey(KeyCode.Z) && !m_gameCtrl.m_pressR)
            {
                m_Anim.SetBool("PICKUP", true);
            }
            else
            {
                m_Anim.SetBool("PICKUP", false);
            }

            if (m_JumpCount < 1 && Input.GetButtonDown("Jump") && !m_gameCtrl.m_pressR)
            {
                m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, 5, m_rigidbody.velocity.z);
                m_JumpCount++;
            }
            m_Anim.SetFloat("JUMP", m_rigidbody.velocity.y);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                m_isRun = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                m_isRun = false;
            }
        }

    }

    public void AttackAreaTrue()
    {
        if (m_player_weapon.activeInHierarchy)
        {
            m_weaponAttackArea.SetActive(true);
        }
        else
        {
            m_handAttackArea.SetActive(true);
        }
    }

    public void AttackAreaFalse()
    {
        if (m_player_weapon.activeInHierarchy)
        {
            m_weaponAttackArea.SetActive(false);
        }
        else
        {
            m_handAttackArea.SetActive(false);
        }
    }

    void character_Rotation()
    {
        float YRotation = Input.GetAxisRaw("Mouse X");
        Vector3 charRotationY = new Vector3(0, YRotation, 0) * m_lookSensitivity;
        m_rigidbody.MoveRotation(m_rigidbody.rotation * Quaternion.Euler(charRotationY));
    }

    void camera_Rotation()
    {
        float XRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = XRotation * m_lookSensitivity;
        m_currentCameraRotationX -= cameraRotationX;
        m_currentCameraRotationX = Mathf.Clamp(m_currentCameraRotationX, -m_cameraRotationLimit, m_cameraRotationLimit);

        m_camera.transform.localEulerAngles = new Vector3(m_currentCameraRotationX, 0, 0);
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        m_Anim.SetBool("WALK", isMove);

        if (isMove)
        {
            Vector3 lookForward = new Vector3(m_cameraArm.forward.x, 0f, m_cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(m_cameraArm.right.x, 0f, m_cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            this.transform.forward = lookForward;

            if (!m_isRun)
            {
                m_Anim.SetBool("RUN", false);
                transform.position += moveDir * Time.deltaTime * m_speed;
            }
            else
            {
                m_Anim.SetBool("RUN", true);
                transform.position += moveDir * Time.deltaTime * m_runSpeed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_JumpCount = 0;
        }
    }

    IEnumerator gameover()
    {
        WaitForSeconds Delay2sec = new WaitForSeconds(2f);
        yield return Delay2sec;

        SceneManager.LoadScene("GameOver");
    }

}
