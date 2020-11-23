using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZombie : EnemyMelee
{
    public GameObject meleeAttackArea;

    private string m_enemyName;
    private float m_maxHP;
    private float m_currentHP;

    private void SetEnemyStatus(string enemyName, int maxHP)
    {
        m_enemyName = enemyName;
        m_maxHP = maxHP;
        m_currentHP = maxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        attackCoolTime = 2f;
        attackCoolTimeCacl = attackCoolTime;

        attackRange = 2.5f;
        m_nav.stoppingDistance = 1f;
        StartCoroutine(ResetAttackArea());

        if(name.Equals("BossZombie") || name.Equals("BossZombie (1)"))
        {
            SetEnemyStatus("Boss Zombie", 200);
        }
        else
        {
            SetEnemyStatus("Zombie", 100);
        }
    }

    IEnumerator ResetAttackArea()
    {
        while (true)
        {
            yield return null;
            if(!meleeAttackArea.activeInHierarchy && currentState == State.ATTACK)
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
   
}
