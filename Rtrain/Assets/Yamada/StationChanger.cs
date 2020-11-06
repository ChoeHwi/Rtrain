using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class StationChanger : MonoBehaviour
{
    /// <summary>配置してあるステージ一覧</summary>
    public GameObject[] allStation;
    /// <summary>乗客一覧</summary>
    public GameObject[] passenger;
    private List<Vector3> savePos = new List<Vector3>();

    private void Start()
    {
    }

    public void StationChange(GameObject station)
    {
        //引数の駅をオンに
        var stationInfo = station.GetComponent<StationInfo>();
        for (int i = 0; i < allStation.Length; i++)
        {
            allStation[i].SetActive(false);
        }
        station.SetActive(true);
        //偉人、非乗客、乗客を生成;
        PeopleIns(stationInfo.passenger, stationInfo.passengerNOP);
        PeopleIns(stationInfo.noPassenger, stationInfo.noPossengerNOP);
        PeopleIns(stationInfo.greatMan, stationInfo.greatManNOP);
        savePos.Clear();
    }

    public void PeopleIns(GameObject people, int nOP)
    {
        Vector3 temPos;
        bool duplicate = false;
        for (int i = 0; i < nOP; i++)
        {
            do
            {
                temPos = new Vector3(Random.Range(-2, 6f), 1, Random.Range(-14f, 14f));
                if (savePos.Count > 0)
                {
                    for (int k = 0; k < savePos.Count; k++)
                    {
                        if (savePos[k] == temPos)
                        {
                            duplicate = true;
                            break;
                        }
                    }
                }
            } while (duplicate);
            savePos.Add(temPos);
            Instantiate(people, temPos, new Quaternion(0, 0, 0, 0));
        }
    }

}
