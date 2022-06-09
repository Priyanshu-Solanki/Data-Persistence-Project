using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InfoSaver : MonoBehaviour
{
    public static InfoSaver instance;

    public InputField inputField;
    public int highScore;
    public string highScorer;
    private void Awake()
    {   
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorer;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScorer = highScorer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefiles.json", json);
    }


    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefiles.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorer = data.highScorer;   
        }
    }
}
