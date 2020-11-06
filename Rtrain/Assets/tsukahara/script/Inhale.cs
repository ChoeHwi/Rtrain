using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inhale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = new Vector3(this.gameObject.transform.position.x - other.gameObject.transform.position.x, 0, this.gameObject.transform.position.z - other.gameObject.transform.position.z).normalized; // 進行方向の単位ベクトルを作る (dir = direction)*/
            rb.velocity = dir * 5f; // 単位ベクトルにスピードをかけて速度ベクトルにして、それを Rigidbody の速度ベクトルとしてセットする
        }
    }
        
}
