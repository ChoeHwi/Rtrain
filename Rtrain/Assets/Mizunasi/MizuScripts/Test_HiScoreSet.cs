using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_HiScoreSet : MonoBehaviour
{
    [SerializeField] Text stage1Text;
    [SerializeField] Text stage2Text;
    [SerializeField] Text stage3Text;
    [SerializeField] Text stage4Text;
    SaveDataSaveLoad m_saveData;
    [SerializeField] 
    List<int> m_hiScoreList;
    // Start is called before the first frame update
    void Start()
    {
        m_saveData = GetComponent<SaveDataSaveLoad>();
        //m_hiScoreList = new List<int>();
        Debug.Log(m_hiScoreList.Count);
    }
    void Update()
    {
        stage1Text.text = "Stage1 : " + m_hiScoreList[0];
        stage2Text.text = "Stage2 : " + m_hiScoreList[1];
        stage3Text.text = "Stage3 : " + m_hiScoreList[2];
        stage4Text.text = "Stage4 : " + m_hiScoreList[3];
    }
    public void Save()
    {
        for (int i = 0; i < m_hiScoreList.Count; i++)
        {
            m_saveData.m_hiScoreData.HiScoreList[i] = m_hiScoreList[i];
        }       
        m_saveData.SaveHiScoreData(m_saveData.m_hiScoreData, m_saveData.json_hiScorePath);
    }
    public void Load()
    {
        for (int i = 0; i < m_saveData.m_hiScoreData.HiScoreList.Count; i++)
        {
            m_hiScoreList[i] = m_saveData.m_hiScoreData.HiScoreList[i];
        }
    }
    
}
