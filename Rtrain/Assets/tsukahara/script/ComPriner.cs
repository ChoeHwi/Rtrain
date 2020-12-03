using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComPriner : MonoBehaviour
{
           
    GameObject GameManager;
    [SerializeField] int socre;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="")
        {
            GameManager gameaMnager = GameManager.GetComponent <GameManager>();
            //gameaMnager.addSocre(socre);
        }
    }
}
