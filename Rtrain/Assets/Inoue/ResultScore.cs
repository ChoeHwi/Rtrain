using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultScore : MonoBehaviour //ResultPanelのテキストのコンポーネントスクリプト
{
    private Text scoreText;
    private UI_Score uI_Score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        uI_Score = GameObject.FindObjectOfType<UI_Score>().GetComponent<UI_Score>();
        scoreText.text += uI_Score.GetScore() + "円";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
