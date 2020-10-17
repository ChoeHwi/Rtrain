using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class Throw : MonoBehaviour
{

    /// <summary>Ray が何にも当たらなかった時、Scene に表示する Ray の長さ</summary>
    [SerializeField] float m_debugRayLength = 100f;
    /// <summary>Ray が何かに当たった時に Scene に表示する Ray の色</summary>
    [SerializeField] Color m_debugRayColorOnHit = Color.red;
    /// <summary>飛ばした Ray が当たった座標に m_marker を移動する際、Ray が当たった座標からどれくらいずらした場所に移動するかを設定する</summary>
    [SerializeField] Vector3 m_markerOffset = Vector3.up / 2;
    /// <summary>今乗客を掴んででいるかどうか</summary>
    public bool isHold;
    /// <summary>掴んでいる乗客</summary>
    public GameObject holdPass;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 乗客をクリックして掴む
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            bool isHit = Physics.Raycast(ray, out hit); 
            if (isHit)
            {
                if(hit.collider.gameObject.tag == "Passenger")
                {
                    holdPass = hit.collider.gameObject;
                    isHold = true;
                }
                Debug.DrawLine(ray.origin, hit.point, m_debugRayColorOnHit);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * m_debugRayLength);
            }
        }

        // 掴んでいる間カーソルと位置を同期
        if (Input.GetButton("Fire1"))
        {
            if (holdPass)
            {
                var cursor = Input.mousePosition;
                cursor.z = 13f;
                var screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(cursor);
                holdPass.transform.position = screenToWorldPointPosition; ;
            }
        }
        
        //　カーソルを離した時乗客を離す
        if (Input.GetButtonUp("Fire1"))
        {
            isHold = false;
            holdPass = null;
        }
    }
}
