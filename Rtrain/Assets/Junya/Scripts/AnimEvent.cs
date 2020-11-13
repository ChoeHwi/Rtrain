using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimEvent : MonoBehaviour
{
    [SerializeField] public GameManager m_gameManager;
   // public GameObject m_trainDir;

    private void Start()
    {
        //m_trainDir = GameObject.Find("TrainDirector");
    }

    public void NextStation()
    {
        m_gameManager.nextStation = true;
        //m_trainDir.GetComponent<TimelinePlayer>().PauseTimeline();
    }
}
