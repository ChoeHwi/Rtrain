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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Passenger")
        {
            collision.gameObject.GetComponent<Passenger>();
            uI_Score.ScoreUpdate(0);
            Destroy(collision.gameObject);
        }
    }
}
