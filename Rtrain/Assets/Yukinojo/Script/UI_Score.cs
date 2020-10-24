using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    private Text scoreText;

    private int score = 0;
    public int GetScore() { return score; }


    void Start()
    {
        scoreText = GetComponent<Text>();
        ReStart();
    }

    void Update()
    {
        
    }

    /// <summary> fare（運賃）を渡してスコアに加えてから更新する関数 </summary>
    /// <param name="fare"></param>
    public void ScoreUpdate(int fare)
    {
        score += fare;
        scoreText.text = "" + score;
    }

    /// <summary> 始め、またはやり直す際にスコアを初期化する関数 </summary>
    public void ReStart()
    {
        score = 0;
        scoreText.text = "" + score;
    }

}
