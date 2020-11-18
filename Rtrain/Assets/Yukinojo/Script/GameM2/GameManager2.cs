using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    /// <summary> シーンの状態 </summary>
    public enum SceneType
    {
        Title,
        Game,
        StageSelect,
    }
    /// <summary> シーンの状態 </summary>
    public SceneType sceneStatus = SceneType.Title;
    /// <summary> 現在のステージ </summary>
    public StageData m_StageData;
    /// <summary> 次の駅に進むかどうか </summary>
    public bool nextStation = false;
    [SerializeField] StationChanger2 stationChanger;
    [SerializeField] TrainCon trainCon;

    public void GameStart(StageData stageData)
    {
        m_StageData = stageData;
        sceneStatus = SceneType.Game;
        trainCon.TrainStart();
    }

}
