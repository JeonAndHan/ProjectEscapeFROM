using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator m_animator;
    string m_prevTriggerName;

    public AnimatorClipInfo[] GetAnimatorClipInfo()
    {
        return m_animator.GetCurrentAnimatorClipInfo(0);
    }
    public float GetPlayTime(string animTriggerName)
    {
        var stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(animTriggerName))
        {
            var length = stateInfo.length;
            return stateInfo.normalizedTime * length;
        }
        return 0f;
    }
    public void Stop()
    {
        Debug.Log("Stop");
        m_animator.speed = 0f;
    }
    public void Resume()
    {
        Debug.Log("Resume");
        m_animator.speed = 1f;
    }
    public float GetAnimationClipLength(string animClipName)
    {
        var ac = m_animator.runtimeAnimatorController;
        var clips = ac.animationClips;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].name.Equals(animClipName))
                return clips[i].length;
        }
        return 0f;
    }
    public void Play(string animTriggerName, bool isFade = true)
    {
        if (!string.IsNullOrEmpty(m_prevTriggerName))
        {
            m_animator.ResetTrigger(m_prevTriggerName);
            m_prevTriggerName = string.Empty;
        }
        if (isFade)
        {
            m_animator.SetTrigger(animTriggerName);
            m_prevTriggerName = animTriggerName;
        }
        else
        {
            m_animator.Play(animTriggerName, 0, 0f);
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_prevTriggerName = string.Empty;
    }
}
