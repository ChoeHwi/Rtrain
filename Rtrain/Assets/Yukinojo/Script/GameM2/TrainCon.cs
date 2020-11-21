using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCon : MonoBehaviour
{
    [SerializeField] GameObject m_train;
    [SerializeField] StationChanger2 stationChanger;
    private Rigidbody m_rb;
    private Vector3 savePos;
    [SerializeField] float speed;
    [SerializeField] float speedUP;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        savePos = this.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            this.transform.position = savePos;
            stationChanger.NextStation();
            speed += -speedUP;
            TrainStart();
        }
    }

    public void TrainStart()
    {
        m_rb.velocity = new Vector3(0, 0, -speed);
    }

}
