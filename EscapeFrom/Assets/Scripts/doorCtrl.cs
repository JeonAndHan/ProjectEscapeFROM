using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCtrl : MonoBehaviour
{
    private int m_hitCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(m_hitCount >= 3)
        //{
        transform.localEulerAngles = new Vector3(0f, -120f, 0f);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //door에 부딪친 것이 player의 attackRange라면 count++;
        if (collision.gameObject.CompareTag("Player"))
        {
            m_hitCount++;
        }
    }
}
