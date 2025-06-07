using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Idle : State
{
    public override void Enter()
    {
        base.Enter();
        m_AnimationController.SetupAnimation(0);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
