using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
/// <summary>
/// SAVEDATAの保存、呼び出しする
/// </summary>
public class SaveDataSaveLoad : MonoBehaviour
{
    public Test_AudioConfigData m_audioConfigData;
    public Test_HiScoreDate m_hiScoreData = new Test_HiScoreDate();
    //public List<int> m_hiScores;
    /// <summary>音量設定の保存先のPath</summary>
    public string json_audioPath { get; private set; }
    /// <summary>ハイスコアの保存先のPath</summary>
    public string json_hiScorePath { get; private set; }
    /// <summary>保存した音量設定を反映させるメソッドが入ってます。 </summary>
    public event Action OnAudioLoadData;
    private void Start()
    {　 //ANDROID用
#if UNITY_ANDROID
        json_audioPath = Application.streamingAssetsPath + "/audiosavedata.json";
        json_hiScorePath = Application.streamingAssetsPath + "/hiscoresavedata.json";
#else
        //非Android
        json_audioPath = Application.dataPath + "/audiosavedata.json";
        json_hiScorePath = Application.dataPath + "/hiscoresavedata.json";
#endif
        
        LoadData(json_audioPath);
        LoadData(json_hiScorePath);
        OnAudioLoadData?.Invoke();
    }
    public void LoadData(string jsonPath)
    {
        if (File.Exists(jsonPath))//ファイルが存在するか
        {
            if (jsonPath == json_audioPath)
            {
                m_audioConfigData = GetAudioData(jsonPath);//jsonを読み込む
            }
            if (jsonPath == json_hiScorePath)
            {
                m_hiScoreData = GetHiScoreData(jsonPath);
            }
        }
        else if (jsonPath == json_audioPath)
        {
            m_audioConfigData = new Test_AudioConfigData();
            //json作る処理
        }
        else if (jsonPath == json_hiScorePath)
        {
            //m_hiScoreData = new Test_HiScoreDate();
            //m_hiScores = m_hiScoreData.hiScoreList;
        }
    }
    #region Audio
    public void SaveAudioData(Test_AudioConfigData configData, string jsonPath)
    {
        StreamWriter writer;
        string saveData = JsonUtility.ToJson(configData);
        writer = new StreamWriter(jsonPath, false);
        writer.Write(saveData);
        writer.Flush();
        writer.Close();
    }
    public Test_AudioConfigData GetAudioData(string jsonPath)
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(jsonPath);
        datastr = reader.ReadToEnd();
        reader.Close();
        return JsonUtility.FromJson<Test_AudioConfigData>(datastr);
    }
    #endregion
    #region HiScore
    public void SaveHiScoreData(Test_HiScoreDate hiScores, string jsonPath)
    {
        StreamWriter writer;
        string saveData = JsonUtility.ToJson(hiScores);
        writer = new StreamWriter(jsonPath, false);
        writer.Write(saveData);
        writer.Flush();
        writer.Close();
    }
    public Test_HiScoreDate GetHiScoreData(string jsonPath)
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(jsonPath);
        datastr = reader.ReadToEnd();
        reader.Close();
        return JsonUtility.FromJson<Test_HiScoreDate>(datastr);
    }
    #endregion
}
