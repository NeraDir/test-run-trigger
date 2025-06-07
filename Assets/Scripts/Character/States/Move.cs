using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    public override void Enter()
    {
        base.Enter();
        m_AnimationController.SetupAnimation(1);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
