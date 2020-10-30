using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class StageGenerator : MonoBehaviour
{
    [SerializeField] StationData[] stationDatas;
    void Start()
    {
        ChangeStage(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeStage(int station, int stationNumber)
    {
        var stationPosition = new Vector3(1.76f, 0f, (0f - 2100 * stationNumber));
        Addressables
            .LoadAssetAsync<GameObject>(stationDatas[station].stationName)
            .Completed += op =>
            {
                Instantiate(op.Result);
            };
        Addressables
            .LoadAssetAsync<GameObject>(stationDatas[station].passengerName)
            .Completed += op =>
            {
                for (int i = 0; i < stationDatas[station].passengerNOP; i++)
                {
                    var position = new Vector3(stationPosition.x + Random.Range(0.1f ,1),0 ,stationPosition.z + Random.Range(-24, 24));
                    Instantiate(op.Result);
                }
            };


    }
}
