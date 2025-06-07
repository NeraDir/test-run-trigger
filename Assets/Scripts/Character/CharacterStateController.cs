using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateController : MonoBehaviour
{
    private State m_CurrentState;

    private void Update()
    {
        if (m_CurrentState != null)
            m_CurrentState.Proccess();
    }

    public State GetCurrentState()
    {
        return m_CurrentState;
    }

    public void ChangeState(State state)
    {
        if (m_CurrentState != null)
            m_CurrentState.Exit();

        m_CurrentState = state;

        if (m_CurrentState != null)
            m_CurrentState.Enter();
    }
}
