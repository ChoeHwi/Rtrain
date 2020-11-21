using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] GameManager2 gameManager;
    [SerializeField] StageData stageData;
    [SerializeField] TrainCon trainCon;

    public void selectClick()
    {
        this.gameObject.SetActive(false);
        gameManager.GameStart(stageData);
    }

}
