using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //電車のシーンに移行　ゲームスタートボタンで呼び出し
    public void GameStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
