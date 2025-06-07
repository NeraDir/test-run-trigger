using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [SerializeField] private float m_Speed;

    private CharacterStateController m_CharacterState;
    private CharacterController m_CharacterController;

    private Idle m_Idle;
    private Move m_Move;

    private Quaternion m_Rotation;
    private Transform m_Transform;

    private float _rotationVelocity = 0;
    private const float RotationSmoothTime = 0.04f;

    private void Awake()
    {
        m_Transform = transform;
        m_Idle = GetComponent<Idle>();
        m_Move = GetComponent<Move>();
        m_CharacterController = GetComponent<CharacterController>();
        m_CharacterState = GetComponent<CharacterStateController>();
    }

    private void Update()
    {
        Vector3 input = GetMovementDirection();
        if (input.x != 0 || input.z != 0)
        {
            if(m_CharacterState != null && m_CharacterState.GetCurrentState() != m_Move)
                m_CharacterState.ChangeState(m_Move);
            Move(input);
            Rotate(input);
        }
        else
        {
            m_Transform.rotation = m_Rotation;
            if (m_CharacterState != null && m_CharacterState.GetCurrentState() != m_Idle)
                m_CharacterState.ChangeState(m_Idle);
        }
    }

    private void Move(Vector3 input)
    {
        Vector3 direction = new Vector3(input.x, 0, input.z);
        m_CharacterController.Move(direction.normalized * m_Speed * Time.deltaTime);
    }

    private void Rotate(Vector3 input)
    {
        float _targetRotation = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg;

        m_Transform.rotation = Quaternion.Euler(0, Mathf.SmoothDampAngle(m_Transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, RotationSmoothTime), 0);
        m_Rotation = m_Transform.rotation;
    }

    private Vector3 GetMovementDirection()
    {
        float x = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        float z = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
        return new Vector3(x, 0, z).normalized;
    }


}
