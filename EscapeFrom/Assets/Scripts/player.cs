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
        if (Input.GetKey(KeyCode.Space))
        {
            m_Anim.SetTrigger("ATTACK");
        }
        else
        {
            m_Anim.SetTrigger("IDLE");
        }
    }

    private void FixedUpdate()
    {
        m_dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        m_rigidbody.MovePosition(transform.position + m_dir * m_speed * Time.fixedDeltaTime);
    }
}
