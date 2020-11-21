using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 音量を変更するためのスクリプト
/// </summary>
public class Test_SetVolume : MonoBehaviour
{

    [SerializeField]  UnityEngine.Audio.AudioMixer m_mixer;
    ///<summary>MasterVolumeを変えるためのSlider</summary>
    [SerializeField]　Slider m_masterSlider;
    ///<summary>BGMVolumeを変えるためのSlider</summary>
    [SerializeField]  Slider m_BGMSlider;
    ///<summary>SEVolumeを変えるためのSlider</summary>
    [SerializeField]  Slider m_SESlider;
    SaveDataSaveLoad m_configData;
    
    public float MasterVolume
    {
        set { m_mixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, value)); }
    }
    public float BgmVolume
    {
        set { m_mixer.SetFloat("BGMVolume", Mathf.Lerp(-80, 0, value)); }
    }
    public float SEVolume
    {
        set { m_mixer.SetFloat("SEVolume", Mathf.Lerp(-80, 0, value)); }
    }
    private void Awake()//Startより先に処理
    {
        m_configData = GetComponent<SaveDataSaveLoad>();
        //保存した設定を反映
        m_configData.OnAudioLoadData += () =>　{
            m_masterSlider.value = m_configData.m_audioConfigData.m_masterVolume;
            m_BGMSlider.value = m_configData.m_audioConfigData.m_BGMVolume;
            m_SESlider.value = m_configData.m_audioConfigData.m_SEVolume;
            //Debug.Log("OnLoadData");
        };
    }
    public void Save()
    {
        m_configData.m_audioConfigData.m_masterVolume = m_masterSlider.value;
        m_configData.m_audioConfigData.m_BGMVolume = m_BGMSlider.value;
        m_configData.m_audioConfigData.m_SEVolume = m_SESlider.value;
        m_configData.SaveAudioData(m_configData.m_audioConfigData, m_configData.json_audioPath);
    }

}
