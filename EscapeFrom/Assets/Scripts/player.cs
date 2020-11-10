using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    float m_speed;
    [SerializeField]
    Vector3 m_dir;

    Rigidbody m_rigidbody;
    CapsuleCollider m_collider;
    Animator m_Anim;

    private int m_JumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<CapsuleCollider>();
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        m_rigidbody.MovePosition(transform.position + m_dir * m_speed * Time.fixedDeltaTime);

        if (Input.GetMouseButton(0))
        {
            m_Anim.SetBool("ATTACK", true);
        }
        else
        {
            m_Anim.SetBool("ATTACK", false);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            m_Anim.SetBool("PICKUP", true);
        }
        else
        {
            m_Anim.SetBool("PICKUP", false);
        }

        if(m_JumpCount < 1 && Input.GetButtonDown("Jump"))
        {
            m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, 6, m_rigidbody.velocity.z);
            m_JumpCount++;
        }
        m_Anim.SetFloat("JUMP", m_rigidbody.velocity.y);

        ///////////HP =0 -> Death로 수정
        //if (Input.GetKey(KeyCode.D))
        //{
        //    m_Anim.SetBool("DEATH", true);
        //}
        //else
        //{
        //    m_Anim.SetBool("DEATH", false);
        //}


        /////////////쳐맞으면 HIT 모션 취하는걸로 수정
        //if (Input.GetKey(KeyCode.X))
        //{
        //    m_Anim.SetBool("HIT", true);
        //}
        //else
        //{
        //    m_Anim.SetBool("HIT", false);
        //}

        //else if (Input.GetKey(KeyCode.Space))
        //{
        //    m_Anim.SetTrigger("JUMP");
        //}

        if (m_dir != Vector3.zero)
        {
            m_Anim.SetBool("WALK", true);
            if(m_dir.x > 0)
            {
                this.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if(m_dir.x < 0)
            {
                this.transform.eulerAngles = new Vector3(0, -90, 0);
            }
            else
            {
                this.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            m_Anim.SetBool("WALK", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_JumpCount = 0;
        }
    }

}
