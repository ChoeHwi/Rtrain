using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainControl : MonoBehaviour
{
    [SerializeField] GameObject m_train;
    [SerializeField] GameManager gameManager;
    Rigidbody m_rb;
    Vector3 savePos;
    [SerializeField] float speed;
    [SerializeField] float speedUp;
    [SerializeField] GameObject fadePanel;
    [SerializeField] StationChanger stationChanger;
    bool moveTrain=true;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        savePos = this.gameObject.transform.position;

    }

    void Update()
    {
        if (gameManager.sceneStatus == GameManager.SceneType.Game&&moveTrain)
        {
            //m_rb.AddForce(new Vector3(0, 0, -5));
            //transform.position += new Vector3(0, 0, -0.1f);
            m_rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            this.transform.position = savePos;
            gameManager.nextStation = true;
            speed += speedUp;
            StartCoroutine("FadeScene");
        }
    }
    IEnumerator FadeScene()
    {
        fadePanel.SetActive(true);
        moveTrain = false;
        m_rb.velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(3.0f);
        gameManager.nextStation = true;
        moveTrain = true;
        fadePanel.SetActive(false);

    }
}
