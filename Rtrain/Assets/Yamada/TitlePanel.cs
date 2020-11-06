using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePanel : MonoBehaviour
{
    public Animator titleTrain;
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
    }
    
}
