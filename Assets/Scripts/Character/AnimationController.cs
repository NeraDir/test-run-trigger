using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private string m_AnimatorKey;

    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = SetupAnimator();
    }

    public void SetupAnimation(bool value)
    {
        m_Animator.SetBool(m_AnimatorKey, value);
    }

    public void SetupAnimation(int value)
    {
        m_Animator.SetInteger(m_AnimatorKey, value);
    }

    private Animator SetupAnimator()
    {
        Animator anima = GetComponent<Animator>();
        if (anima == null)
        {
            anima = GetComponentInChildren<Animator>();
            return anima;
        }
        return anima;
    }
}
