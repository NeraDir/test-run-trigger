using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSaves : MonoBehaviour
{
    public static GameSaves Instance;

    private const string SAVE_KEY = "test_game_save_key";

    [HideInInspector]
    public int Points = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Load()
    {
        string save = PlayerPrefs.GetString(SAVE_KEY);
        if (!string.IsNullOrEmpty(save))
        {
            var loaded = JsonConvert.DeserializeObject<DataSave>(save);
            if (loaded != null)
                this.Points = loaded.Points;
        }
    }

    public void Save()
    {
        DataSave data = new DataSave();
        data.Points = this.Points;
        string save = JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(SAVE_KEY, save);
    }
}

[Serializable]
public class DataSave
{
    public int Points = 0;
}
