using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationInfo : MonoBehaviour
{
    /// <summary>駅の名前</summary>
    public string stationName;
    /// <summary>一般乗客</summary>
    [SerializeField] public GameObject passenger;
    /// <summary>一般乗客の人数</summary>
    [SerializeField] public int passengerNOP;
    /// <summary>非乗客</summary>
    [SerializeField] public GameObject noPassenger;
    /// <summary>非乗客の人数</summary>
    [SerializeField] public int noPossengerNOP;
    /// <summary>偉人</summary>
    [SerializeField] public GameObject greatMan;
    /// <summary>偉人の人数</summary>
    [SerializeField] public int greatManNOP;
}
