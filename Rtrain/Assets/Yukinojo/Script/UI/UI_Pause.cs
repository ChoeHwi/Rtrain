using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseScreenPanel;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    /// <summary> PausePanelの「active化」と「非active化」を行う関数 </summary>
    public void SetActivePauseScreenPanel()
    {
        if (pauseScreenPanel.activeInHierarchy)
        {
            pauseScreenPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseScreenPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
