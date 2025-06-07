using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : State
{
    public override void Enter()
    {
        base.Enter();
        m_AnimationController.SetupAnimation(2);
    }

    public override void Exit()
    {
        base.Exit();
        GameState.onAddPoint?.Invoke(1);
        Destroy(gameObject);
    }
}
