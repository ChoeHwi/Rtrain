using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    public PlayableDirector m_trainDirector;

    void Start()
    {
        //同じゲームオブジェクトにあるPlayableDirectorを取得する
        m_trainDirector = GetComponent<PlayableDirector>();
    }

    //再生する
    public void PlayTimeline()
    {
        m_trainDirector.Play();
    }

    //一時停止する
    public void PauseTimeline()
    {
        m_trainDirector.Pause();
    }

    //一時停止を再開する
    public void ResumeTimeline()
    {
        m_trainDirector.Resume();
    }

    //停止する
    void StopTimeline()
    {
        m_trainDirector.Stop();
    }

}