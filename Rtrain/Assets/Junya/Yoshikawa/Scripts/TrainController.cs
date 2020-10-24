using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] GameObject m_train;
    //リザルトのパネル
    [SerializeField] GameObject m_resultpanel;
    Rigidbody m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_rb.AddForce(new Vector3(0, 0, -5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            m_resultpanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}