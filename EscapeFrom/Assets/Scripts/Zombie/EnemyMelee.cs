using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    public enum State
    {
        IDLE,
        WALK,
        ATTACK,
    };

    public State currentState = State.IDLE;
    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        StartCoroutine(FSM());
    }

    protected virtual IEnumerator FSM()
    {
        yield return null;
        //player가 방을 벗어나지 않았다면 idle 상태로 대기
        // while()

        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    protected virtual IEnumerator IDLE()
    {
        yield return null;

        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            m_Anim.SetTrigger("IDLE");
        }

        if (CanAttackState())
        {
            if (canAttack)
            {
                currentState = State.ATTACK;
            }
            else
            {
                currentState = State.IDLE;
                transform.LookAt(m_player.transform.position);
            }
        }
        else
        {
            currentState = State.WALK;
        }
    }

    protected virtual IEnumerator ATTACK()
    {
        yield return null;

        m_nav.stoppingDistance = 1f;
        m_nav.isStopped = true;
        //m_nav.SetDestination(m_player.transform.position);
        //yield return Delay500;

        m_nav.isStopped = false;
        //m_nav.speed = 2.5f;
        canAttack = false;

        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("ATTACK"))
        {
            Debug.Log("Attack Anim");
            m_Anim.SetTrigger("ATTACK");
        }
        yield return Delay500;

        m_nav.speed = 2.5f;
        m_nav.stoppingDistance = attackRange;
        currentState = State.IDLE;

    }

    protected virtual IEnumerator WALK()
    {
        yield return null;

        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("WALK"))
        {
            m_Anim.SetTrigger("WALK");
        }

        if(CanAttackState() && canAttack)
        {
            currentState = State.ATTACK;
        }
        else if( distance > 7f)
        {
            m_nav.SetDestination(transform.position - Vector3.forward * 5f);
        }
        else
        {
            m_nav.SetDestination(m_player.transform.position);
        }
    }

}
