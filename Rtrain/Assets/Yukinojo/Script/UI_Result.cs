using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Result : MonoBehaviour
{
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject resultScoreTextObj;
    private Text resultScoreText;
    [SerializeField] GameObject scoreObj;
    private UI_Score score;

    void Start()
    {
        resultScoreText = resultScoreTextObj.GetComponent<Text>();
        score = scoreObj.GetComponent<UI_Score>();
    }

    void Update()
    {
        
    }

    /// <summary> ResultPanelの「active化」と「非active化」を行う関数 </summary>
    public void SetActiveResultPanel()
    {
        if (resultPanel.activeInHierarchy)
        {
            resultPanel.SetActive(false);
        }
        else
        {
            resultPanel.SetActive(true);
            SetResultScore();
        }
    }

    private void SetResultScore()
    {
        resultScoreText.text = "" + score.GetScore();
    }

}
