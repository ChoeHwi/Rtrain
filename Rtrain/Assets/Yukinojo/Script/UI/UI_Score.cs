using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    private Text scoreText;

    private int score = 0;
    public int GetScore() { return score; }

    private int passengerCount = 0;
    public int GetPassengerCount() { return passengerCount; }
    private int noPassengerCount = 0;
    public int GetNoPassengerCount() { return noPassengerCount; }
    private int greatPassengerCount = 0;
    public int GetGreatPassengerCount() { return greatPassengerCount; }


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

    /// <summary> 始め、またはやり直す際にスコアと人数を初期化する関数 </summary>
    public void ReStart()
    {
        score = 0;
        scoreText.text = "" + score;
        passengerCount = 0;
        noPassengerCount = 0;
        greatPassengerCount = 0;
    }

    /// <summary> いずれかの乗客を乗せた際にtagの名前を渡して人数をカウントしておく関数 </summary>
    /// <param name="tagName"></param>
    public void AnyPassengerCountUpdate(string tagName)
    {
        switch (tagName)
        {
            case "Passenger":
                passengerCount++;
                break;
            case "NoPassenger":
                noPassengerCount++;
                break;
            case "GreatPassenger":
                greatPassengerCount++;
                break;
            default:
                break;
        }
    }

}
