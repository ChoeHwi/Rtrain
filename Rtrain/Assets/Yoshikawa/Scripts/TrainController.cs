using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] GameObject train;
    //リザルトのパネル
    [SerializeField] GameObject resultpanel;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(new Vector3(0, 0, -5));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            resultpanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
