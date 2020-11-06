using UnityEngine;

public class Test_SoundSettingPopup : MonoBehaviour
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
