using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] GameObject m_train;
    [SerializeField] GameManager gameManager;
    Rigidbody m_rb;
    Vector3 savePos;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        savePos = this.gameObject.transform.position;
    }

    void Update()
    {
        if (gameManager.sceneStatus == GameManager.SceneType.Game)
        {
            m_rb.AddForce(new Vector3(0, 0, -5));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            this.transform.position = savePos;
            gameManager.nextStation = true;
        }
    }
}
