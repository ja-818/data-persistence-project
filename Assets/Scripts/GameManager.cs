using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string currentPlayerName;

    [System.Serializable]
    public class HighScore
    {
        public int score;
        public string playerName;
    }

    public HighScore highScore = new HighScore();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void SaveHighScore()
    {
        string json = JsonUtility.ToJson(highScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore hScore = JsonUtility.FromJson<HighScore>(json);

            highScore = hScore;
        }
    }
}
