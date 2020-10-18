using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : PassengerBase
{
    [SerializeField] int m_fare;
    GameObject Score;

    public override void PayMent()
    {
        Score = GameObject.Find("Score");
        Score.GetComponent<UI_Score>().ScoreUpdate(m_fare);
    }
}