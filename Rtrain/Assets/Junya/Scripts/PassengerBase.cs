using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassengerBase : MonoBehaviour
{
    GameManager2 gameManager;
    public GameObject Score;
    private void Start()
    {
        gameManager =  GameObject.Find("GameManager").GetComponent<GameManager2>();
    }
    private void Update()
    {
        /*if (gameManager.nextStation)
        {
            Destroy(this.gameObject);
        }*/
    }
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
    // 所詮テストコードになりそう
    public abstract void PayMent();
}