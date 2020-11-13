using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Result : MonoBehaviour
{
    [SerializeField] GameObject resultPanel;

    [SerializeField] GameObject scoreObj;
    private UI_Score score;
    [SerializeField] GameObject resultScoreTextObj;
    private Text resultScoreText;
    [SerializeField] GameObject resultPassengerTextObj;
    private Text resultPassengerCountText;
    [SerializeField] GameObject resultNoPassengerTextObj;
    private Text resultNoPassengerCountText;
    [SerializeField] GameObject resultGreatPassengerTextObj;
    private Text resultGreatPassengerCountText;

    void Start()
    {
        score = scoreObj.GetComponent<UI_Score>();
        resultScoreText = resultScoreTextObj.GetComponent<Text>();
        resultPassengerCountText = resultPassengerTextObj.GetComponent<Text>();
        resultNoPassengerCountText = resultNoPassengerTextObj.GetComponent<Text>();
        resultGreatPassengerCountText = resultGreatPassengerTextObj.GetComponent<Text>();
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
        resultScoreText.text = "今回のスコア　" + score.GetScore();
        resultPassengerCountText.text = "乗せた乗客　" + score.GetPassengerCount() + "　人";
        resultNoPassengerCountText.text = "乗せた非乗客　" + score.GetNoPassengerCount() + "　人";
        resultGreatPassengerCountText.text = "乗せた偉人　" + score.GetGreatPassengerCount() + "　人";
    }

}
