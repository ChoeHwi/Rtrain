using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody m_rb;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            gameManager.nextStation = true;
        }
    }
}
