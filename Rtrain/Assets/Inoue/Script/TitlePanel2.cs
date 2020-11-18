using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePanel2 : MonoBehaviour
{
    public Animator titleTrain;
    [SerializeField] GameObject selectPanel;
    private void Start()
    {
        TitleOn();
    }
    public void TitleOn()
    {
        this.gameObject.SetActive(true);
        titleTrain.SetTrigger("Title");
    }
    public void TitleOff()
    {
        this.gameObject.SetActive(false);
        selectPanel.SetActive(true);
    }
}
