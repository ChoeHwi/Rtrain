using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassengerBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            PayMent();
            gameObject.SetActive(false);
        }   
    }

    // お金を支払う関数だよ
    // 今後クレーマー？みたいなやつの実装のために抽象関数で作るお
    public abstract void PayMent();
}