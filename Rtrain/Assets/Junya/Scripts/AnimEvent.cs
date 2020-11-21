using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class AnimEvent : MonoBehaviour
{
    [SerializeField] public GameManager m_gameManager;
    [SerializeField] UI_Result uI_Result;
    [SerializeField] Image m_fadeImage;
    int i = 0;
    public GameObject m_trainDir;

    private void Start()
    {
        m_trainDir = GameObject.Find("TrainDirector");
    }

    public void NextStation()
    {
        /*i++;
        Debug.Log(i);
        m_gameManager.nextStation = true;
        if (i == 3)
        {
            uI_Result.SetActiveResultPanel();
            m_trainDir.GetComponent<TimelinePlayer>().PauseTimeline();
            m_fadeImage.gameObject.SetActive(false);
        }*/
        
    }
}
