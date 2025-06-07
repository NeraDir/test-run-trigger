using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusWidget : MonoBehaviour
{
    [SerializeField] private PlateComponent m_PlateComponent;

    [SerializeField] private Image m_FillImage;
    [SerializeField] private TMP_Text m_StatusTxt;

    [SerializeField] private float m_MaxProgress = 3;

    private GameObject m_GameObject;

    private float m_Progress = 0;
    private bool m_Proccess;

    private IMotion[] m_Motions;

    private void Awake()
    {
        m_Motions = GetComponentsInChildren<IMotion>();
        m_PlateComponent.onPressed += OnPressed;
        m_GameObject = gameObject;
        m_GameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        m_PlateComponent.onPressed -= OnPressed;
    }

    private void OnPressed(bool value)
    {
        m_Proccess = value;
        m_GameObject.SetActive(value);
        m_Progress = 0;
    }

    private void LateUpdate()
    {
        if (m_Proccess)
        {
            m_Progress += Time.deltaTime;
            if (m_Progress >= m_MaxProgress)
            {
                foreach (var item in m_Motions)
                {
                    item.Use();
                }
                m_Progress = 0;
            }
            UpdateVisual();
        }
    }

    private void UpdateVisual()
    {
        m_FillImage.fillAmount = Mathf.Clamp(m_FillImage.fillAmount, (m_Progress / m_MaxProgress), 8 * Time.deltaTime);
        m_StatusTxt.text = m_Progress.ToString("0");
    }
}
