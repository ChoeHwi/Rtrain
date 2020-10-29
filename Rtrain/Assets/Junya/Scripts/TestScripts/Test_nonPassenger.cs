using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_nonPassenger : PassengerBase
{
    // とりま仕様が話合いできてなさすぎだから罰金って形にしといたお
    public int m_fine;
    public override void PayMent()
    {
        Score = GameObject.Find("Score");
        Score.GetComponent<UI_Score>().ScoreUpdate(m_fine);
    }
}
