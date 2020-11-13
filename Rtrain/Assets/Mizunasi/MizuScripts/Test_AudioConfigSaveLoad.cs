using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
/// <summary>
/// 音量設定のDATAの保存、呼び出しする
/// </summary>
public class Test_AudioConfigSaveLoad : MonoBehaviour
{
    public Test_AudioConfigData m_audioConfigData;
    private string json_path;
    /// <summary>保存した音量設定を反映させるメソッドが入ってます。 </summary>
    public event Action OnLoadData;
    private void Start()
    {　 //ANDROID用
#if UNITY_ANDROID
        json_path = Application.streamingAssetsPath + "/savedata.json";
#else
        //非Android
        json_path = Application.dataPath + "/audiosavedata.json";
#endif
        LoadData();
    }
    public void SaveConfigData(Test_AudioConfigData configData)
    {
        StreamWriter writer;
        string saveData = JsonUtility.ToJson(configData);
        writer = new StreamWriter(json_path, false);
        writer.Write(saveData);
        writer.Flush();
        writer.Close();
    }
    public void LoadData()
    {
        if (File.Exists(json_path))//ファイルが存在するか
        {
            m_audioConfigData = GetRecordData();//jsonを読み込む
        }
        else
        {
            m_audioConfigData = new Test_AudioConfigData();
            //json作る処理
        }
        OnLoadData?.Invoke();
        Debug.Log(m_audioConfigData.m_masterVolume);
    }
    public Test_AudioConfigData GetRecordData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(json_path);
        datastr = reader.ReadToEnd();
        reader.Close();
        return JsonUtility.FromJson<Test_AudioConfigData>(datastr);
    }
}
