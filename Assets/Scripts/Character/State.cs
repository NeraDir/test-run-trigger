using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public AnimationController m_AnimationController { get; private set; }

    private void Awake()
    {
        m_AnimationController = GetComponent<AnimationController>();
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Proccess()
    {

    }

    public virtual void Exit()
    {

    }
}
