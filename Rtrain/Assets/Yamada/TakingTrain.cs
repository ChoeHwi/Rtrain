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
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Passenger")
    //    {
    //        Passenger passenger= collision.gameObject.GetComponent<Passenger>();
    //        uI_Score.ScoreUpdate(passenger.m_fare);
    //        Destroy(collision.gameObject);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            Passenger passenger = other.gameObject.GetComponent<Passenger>();
            uI_Score.ScoreUpdate(passenger.m_fare);
            Destroy(other.gameObject);
        }
    }
}
