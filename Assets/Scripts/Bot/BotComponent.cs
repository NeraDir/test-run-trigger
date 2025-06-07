using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotComponent : MonoBehaviour
{
    [SerializeField] private float m_DanceTime = 3;

    private IAstarAI m_Ai;
    private CharacterStateController m_CharacterStateController;

    private Idle m_IdleState;
    private Move m_MoveState;
    private Dance m_DanceState;

    private bool m_Moving = false;

    public void Init()
    {
        m_CharacterStateController = GetComponent<CharacterStateController>();
        m_IdleState = GetComponent<Idle>();
        m_MoveState = GetComponent<Move>();
        m_DanceState = GetComponent<Dance>();

        m_Ai = GetComponent<IAstarAI>();
        m_CharacterStateController.ChangeState(m_IdleState);
    }

    private void Update()
    {
        if (m_Moving)
        {
            if (m_Ai.reachedEndOfPath)
            {
                m_CharacterStateController.ChangeState(m_DanceState);
                m_Moving = false;
                StartCoroutine(WaitDanceAndExit());
            }
        }
    }

    private IEnumerator WaitDanceAndExit()
    {
        yield return new WaitForSeconds(m_DanceTime);
        m_CharacterStateController.ChangeState(null);
    }

    public void Move()
    {
        m_Moving = true;
        m_CharacterStateController.ChangeState(m_MoveState);
    }
}
