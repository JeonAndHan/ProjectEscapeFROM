using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZombie : MonoBehaviour
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
        
    }
}
