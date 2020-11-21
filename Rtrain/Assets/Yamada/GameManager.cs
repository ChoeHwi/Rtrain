﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>シーンの状態</summary>
    public SceneType sceneStatus = SceneType.Title;
    /// <summary>現在のステージ</summary>
    public StageData m_stationData;
    /// <summary>電車が駅を通り過ぎたよって合図</summary>
    public bool nextStation = false;
    [SerializeField] StationChanger stationChanger;
    [SerializeField] Throw throwS;
    [SerializeField] TitlePanel titlePane;
    [SerializeField] UI_Result uI_Result;

    public void GameStart(StageData stageData)
    {
        sceneStatus = SceneType.Game;
        StartCoroutine("Game", stageData);
    }

    public IEnumerator Game(StageData stageData)
    {
        for (int i = 0; i < stageData.station.Count(); i++)
        {
            while (!nextStation)
            {
                yield return null;
            }
            Debug.Log(stageData.station[i]);
            stationChanger.StationChange(stageData.station[i]);
            nextStation = false;
        }
        //uI_Result.SetActiveResultPanel();
    }

    /// <summary>画面の状態の種類</summary>
    public enum SceneType
    {
        Title,
        Game,
        Settings,

    }
}
