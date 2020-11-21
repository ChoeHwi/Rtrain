using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    RectTransform rect;
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    bool fulick = false;
    
    Vector3 pos;
    int panelCount = 1;
    [SerializeField] int minPanelcount = 1;
    [SerializeField] int maxPanelCount = 4;
    // Start is called before the first frame update
    void Start()
    {
        rect= panel.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
        if (fulick)
        {
            var v = Vector3.zero;

            rect.transform.position = Vector3.SmoothDamp(rect.transform.position, pos, ref v, 0.01f);
        }
        
    }
    

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            //フリックし終わったら
            GetDirection();
        }
    }
    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;


        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            Debug.Log($"{"パネル"}, {rect.transform.position}");
            Debug.Log($"{"初期"}, {rect.transform.position}");
            if (30 < directionX && panelCount!=minPanelcount)
            {
                //右向きにフリック
                
                panelCount -= 1;
                fulick = true;
                pos = rect.transform.position;
                pos.x += 1080;
            }
            else if (-30 > directionX && panelCount!=maxPanelCount)
            {
                //左向きにフリック
                panelCount += 1;
                fulick = true;
                pos = rect.transform.position;
                pos.x -= 1080;
            }
        }
       
    }

}
