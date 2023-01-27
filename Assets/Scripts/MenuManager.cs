using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string playerName, bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string bestPlayerName;
        public int bestScore;
    }
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestPlayerName= bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
}
