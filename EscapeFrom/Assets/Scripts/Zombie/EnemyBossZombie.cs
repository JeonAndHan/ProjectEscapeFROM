using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossZombie : EnemyMelee
{
    public GameObject meleeAttackArea;

    [SerializeField]
    private float m_maxHP;
    [SerializeField]
    private float m_currentHP;

    private player m_Target;


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        attackCoolTime = 2f;
        attackCoolTimeCacl = attackCoolTime;

        attackRange = 2.5f;
        m_nav.stoppingDistance = 1f;
        StartCoroutine(ResetAttackArea());

        m_currentHP = m_maxHP;

    }

    public void Hit(float damage)
    {
        m_currentHP -= damage;
        m_Anim.SetTrigger("HIT");

        if(m_currentHP <= 0)
        {
            m_Anim.SetTrigger("DEATH");
        }
    }

    IEnumerator ResetAttackArea()
    {
        while (true)
        {
            yield return null;
            if (!meleeAttackArea.activeInHierarchy && currentState == State.ATTACK)
            {
                yield return new WaitForSeconds(attackCoolTime);
                meleeAttackArea.SetActive(true);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //부딪친 대상이 player고 지금 좀비가 attack 상태라면
        if(collision.gameObject.CompareTag("Player") && currentState == State.ATTACK)
        {
            m_Target = collision.gameObject.GetComponent<player>();
            m_Target.Hit(20);
        }
    }
}
