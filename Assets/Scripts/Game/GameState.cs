using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static Action<int> onAddPoint;

    [SerializeField] private TMP_Text m_PointsTxt;

    private void Start()
    {
        onAddPoint += OnAddPoint;
        OnAddPoint(0);
    }

    private void OnDestroy()
    {
        onAddPoint -= OnAddPoint;
    }

    private void OnAddPoint(int value)
    {
        GameSaves.Instance.Points += value;
        m_PointsTxt.text = GameSaves.Instance.Points.ToString("0");
        GameSaves.Instance.Save();
    }
}
