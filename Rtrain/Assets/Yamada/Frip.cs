using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Frip : MonoBehaviour
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
        // 乗客をクリックして選択
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isHit = Physics.Raycast(ray, out hit);
            if (isHit)
            {
                if (hit.collider.gameObject.tag == "Passenger" || hit.collider.gameObject.tag == "NoPassenger" || hit.collider.gameObject.tag == "GreatPassenger")
                {
                    holdPass = hit.collider.gameObject;
                    isHold = true;
                    rb = holdPass.GetComponent<Rigidbody>();
                    holdPosition = holdPass.transform.position;
                }
                Debug.DrawLine(ray.origin, hit.point, m_debugRayColorOnHit);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * m_debugRayLength);
            }
        }

        //　カーソルを離した時乗客を飛ばす
        if (Input.GetButtonUp("Fire1"))
        {
            if (isHold && holdPass)
            {
                isHold = false;
                throwPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
                var directionX = throwPosition.x - holdPosition.x;
                var directionZ = throwPosition.z - throwPosition.z;
                //if (Mathf.Abs(directionZ) < Mathf.Abs(directionX))
                //{
                    if (30 < directionX)
                    {
                        //右向きにフリック
                        Vector3 force = new Vector3(throwPosition.x - holdPosition.x, 0, throwPosition.z - holdPosition.z).normalized * 3f;
                        rb.AddForce(force, ForceMode.Impulse);
                    }
                    else if (-30 > directionX)
                    {
                        //左向きにフリック
                        Vector3 force = new Vector3(throwPosition.x - holdPosition.x, 0, throwPosition.z - holdPosition.z).normalized * 3f;
                        rb.AddForce(force, ForceMode.Impulse);
                    }
                //}
                holdPass = null;
            }
        }
    }
}
