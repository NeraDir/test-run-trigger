using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateComponent : MonoBehaviour, IInteractable
{
    [SerializeField] private Color m_PressedColor;
    [SerializeField] private Color m_DefaultColor;
    [SerializeField] private float m_Y;

    [SerializeField] private StatusWidget m_StatusWidget;

    private MeshRenderer m_MeshRenderer = null;
    private Transform m_Transform = null;

    public Action<bool> onPressed;

    private Vector3 m_BeginPosition = Vector3.zero;
    private Vector3 m_TargetPosition = Vector3.zero;

    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_Transform = transform;
        m_BeginPosition = m_Transform.position;
        m_TargetPosition = new Vector3(m_BeginPosition.x, m_BeginPosition.y - m_Y, m_BeginPosition.z);
        m_MeshRenderer.material.DOColor(m_DefaultColor,0.1f);
    }

    public void Use()
    {
       
    }

    public void OnEnter()
    {
        m_MeshRenderer.material.DOColor(m_PressedColor, 0.1f).OnComplete(() => onPressed?.Invoke(true));
        m_Transform.DOMoveY(m_TargetPosition.y, 0.1f);
        
    }

    public void OnExit()
    {
        m_MeshRenderer.material.DOColor(m_DefaultColor, 0.1f).OnComplete(() => onPressed?.Invoke(false));
        m_Transform.DOMoveY(m_BeginPosition.y, 0.1f);
    }
}
