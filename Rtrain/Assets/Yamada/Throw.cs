using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

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
    /// <summary>掴んでいる乗客のRigidbody</summary>
    private Rigidbody rb;
    /// <summary>乗客を掴んだ位置</summary>
    private Vector3 holdPosition;
    /// <summary>乗客を離した位置</summary>
    private Vector3 throwPosition; 


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
                    rb = holdPass.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    holdPosition = holdPass.transform.position;
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
            if (isHold && holdPass)
            {
                var cursor = Input.mousePosition;
                cursor.z = 26f;
                var screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(cursor);
                holdPass.transform.position = screenToWorldPointPosition;
            }
        }
        
        //　カーソルを離した時乗客を離す
        if (Input.GetButtonUp("Fire1"))
        {
            if (isHold && holdPass)
            {
                isHold = false;
                rb.isKinematic = false;
                throwPosition = holdPass.transform.position;
                Vector3 force = new Vector3(throwPosition.x - holdPosition.x, 0, throwPosition.z - holdPosition.z).normalized * 3f;
                rb.AddForce(force, ForceMode.Impulse);
                holdPass = null;
            }
        }
    }
}
