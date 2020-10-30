using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StationData",menuName = "Create StationDate")]
public class StationData : ScriptableObject
{
    /// <summary>駅の名前</summary>
    public string stationName;
    /// <summary>乗客の名前</summary>
    public string passengerName;
    /// <summary>ホームに配置する乗客の人数</summary>
    public int passengerNOP;
}
