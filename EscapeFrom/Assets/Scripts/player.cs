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

        //else if (Input.GetKey(KeyCode.Space))
        //{
        //    m_Anim.SetTrigger("JUMP");
        //}

        if(m_dir != Vector3.zero)
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

}
