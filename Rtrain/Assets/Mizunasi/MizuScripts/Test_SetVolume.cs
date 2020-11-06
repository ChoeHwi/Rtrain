﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test_SetVolume : MonoBehaviour
{

    [SerializeField]
    UnityEngine.Audio.AudioMixer m_mixer;
    [SerializeField]
    Slider m_masterSlider;
    [SerializeField]
    Slider m_BGMSlider;
    [SerializeField]
    Slider m_SESlider;
    Test_AudioConfigSaveLoad m_configData;
    
    
    public float masterVolume
    {
        set { m_mixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, value)); }
    }
    public float bgmVolume
    {
        set { m_mixer.SetFloat("BGMVolume", Mathf.Lerp(-80, 0, value)); }
    }
    public float seVolume
    {
        set { m_mixer.SetFloat("SEVolume", Mathf.Lerp(-80, 0, value)); }
    }
    private void Awake()//Startより先に処理
    {
        m_configData = GetComponent<Test_AudioConfigSaveLoad>();
        //保存した設定を反映
        m_configData.OnLoadData += () =>　{
            m_masterSlider.value = m_configData.m_audioConfigData.m_masterVolume;
            m_BGMSlider.value = m_configData.m_audioConfigData.m_BGMVolume;
            m_SESlider.value = m_configData.m_audioConfigData.m_SEVolume;
            Debug.Log("OnLoadData");
        };
    }
    public void Save()
    {
        m_configData.m_audioConfigData.m_masterVolume = m_masterSlider.value;
        m_configData.m_audioConfigData.m_BGMVolume = m_BGMSlider.value;
        m_configData.m_audioConfigData.m_SEVolume = m_SESlider.value;
        m_configData.SaveConfigData(m_configData.m_audioConfigData);
    }

}
