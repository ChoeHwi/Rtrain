using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>シーンの状態</summary>
    public SceneType sceneStatus = SceneType.Title;
    [SerializeField] StationChanger stationChanger;
    [SerializeField] Throw throwS;
    [SerializeField] TitlePanel titlePane;
    /// フェード用のイメージ
    [SerializeField] Image m_fadeImage;
    /// スコア用のパネル
    [SerializeField] UI_Result uI_Result;
    /// タイムライン
    public GameObject m_trainDir;
    /// インデックス
    public int ind = 0;
    /// <summary>現在のステージ</summary>
    public StageData m_StageData;

    public void GameStart(StageData stageData)
    {
        m_trainDir = GameObject.Find("TrainDirector");
        sceneStatus = SceneType.Game;
        m_StageData = stageData;
        NextStation();
    }

    public void NextStation()
    {
        Debug.Log(ind);
        if (ind < m_StageData.station.Count())
        {
            stationChanger.StationChange(m_StageData.station[ind]);
            ind++;
        }
        else
        {
            uI_Result.SetActiveResultPanel();
            m_trainDir.GetComponent<TimelinePlayer>().PauseTimeline();
            m_fadeImage.gameObject.SetActive(false);
            ind = 0;
            m_StageData = null;
        }
    }

    /// <summary>画面の状態の種類</summary>
    public enum SceneType
    {
        Title,
        Game,
        Settings,
    }
}
