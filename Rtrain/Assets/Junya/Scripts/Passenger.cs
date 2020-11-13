using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : PassengerBase
{
    // 乗客がお金もってないとね♪
    public int m_fare;

    // お金を支払うメソッドだよ♪
    public override void PayMent()
    {
        Score = GameObject.Find("Score");
        Score.GetComponent<UI_Score>().ScoreUpdate(m_fare);
        Score.GetComponent<UI_Score>().AnyPassengerCountUpdate(this.gameObject.tag);
    }
}