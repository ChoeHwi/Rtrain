﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>シーンの状態</summary>
    public SceneType sceneStatus = SceneType.Title;
    /// <summary>ゲームの状態</summary>
    public GameType gameStatus = GameType.None;
    /// <summary>現在のステージ</summary>
    public StageData m_stationData;
    /// <summary>電車が駅を通り過ぎたよって合図</summary>
    public bool nextStation = false;
    [SerializeField] StationChanger stationChanger;
    [SerializeField] Throw throwS;
    [SerializeField] TitlePanel titlePane;
    
    public void GameStart(StageData stageData)
    {
        StartCoroutine("Game", stageData);
    }

    public IEnumerator Game(StageData stageData)
    {
        for (int i = 0; i < stageData.station.Count(); i++ )
        {
            stationChanger.StationChange(stageData.station[i]);
            if (!nextStation)
            {
                yield return null;
            }
            nextStation = false;
        }
    }

    /// <summary>画面の状態の種類</summary>
    public enum SceneType
    {
        Title,
        Game,
        Settings,

    }

    /// <summary>ゲームの状態の種類</summary>
    public enum GameType
    { 
        None,
        Station,
        BetweenStations
    }


}
