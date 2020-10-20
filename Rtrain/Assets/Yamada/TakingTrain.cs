using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingTrain : MonoBehaviour
{
    private UI_Score uI_Score;
    private void Start()
    {
        uI_Score = GameObject.FindObjectOfType<UI_Score>().GetComponent<UI_Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Passenger")
        {
            int m_fare = other.gameObject.GetComponent<Passenger>().m_fare;
            uI_Score.ScoreUpdate(m_fare);
            Destroy(other.gameObject);
        }
    }
}
