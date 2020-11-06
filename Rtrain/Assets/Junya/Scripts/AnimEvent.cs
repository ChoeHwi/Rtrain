using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimEvent : MonoBehaviour
{
    private GameManager m_gameManager = new GameManager();
    public GameObject m_trainDir;

    private void Start()
    {
        m_trainDir = GameObject.Find("TrainDirector");
    }

    public void NextStation()
    {
        Debug.Log("animationEvent発生だぽん");
        m_gameManager.nextStation = true;
        //m_trainDir.GetComponent<TimelinePlayer>().PauseTimeline();
    }
}
