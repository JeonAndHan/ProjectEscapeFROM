using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackArea : MonoBehaviour
{
    [SerializeField]
    private player m_player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("부딪친 대상 : " + other.gameObject.name);
        if(other.gameObject.CompareTag("Zombie") || other.gameObject.CompareTag("BossZombie"))
        {
            m_player.attackTarget(other.gameObject);
        }
    }
}
