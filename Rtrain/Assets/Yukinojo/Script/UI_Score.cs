﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    private Text scoreText;
    public int score = 0;

    void Start()
    {
        scoreText = GetComponent<Text>();
        ReStart();
    }

    void Update()
    {
        
    }

    public void ScoreUpdate(int fare)
    {
        score += fare;
        scoreText.text = "" + score;
    }

    public void ReStart()
    {
        score = 0;
        scoreText.text = "" + score;
    }

}
