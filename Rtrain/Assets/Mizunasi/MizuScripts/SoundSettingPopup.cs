using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettingPopup : MonoBehaviour
{
    [SerializeField]
    GameObject m_SoundPanel;

    public void SoundPanelPopup()
    {
        m_SoundPanel.SetActive(true);
    }
    public void SoundPanelPopdown()
    {
        m_SoundPanel.SetActive(false);
    }
}
