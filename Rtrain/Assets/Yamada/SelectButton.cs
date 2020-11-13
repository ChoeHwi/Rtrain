using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] StageData stageData;
    public void selectClick()
    {
        this.gameObject.SetActive(false);
        gameManager.GameStart(stageData);
    }
}
