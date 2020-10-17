using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    /// <summary>Ray が何にも当たらなかった時、Scene に表示する Ray の長さ</summary>
    [SerializeField] float m_debugRayLength = 100f;
    /// <summary>Ray が何かに当たった時に Scene に表示する Ray の色</summary>
    [SerializeField] Color m_debugRayColorOnHit = Color.red;
    /// <summary>飛ばした Ray が当たった座標に m_marker を移動する際、Ray が当たった座標からどれくらいずらした場所に移動するかを設定する</summary>
    [SerializeField] Vector3 m_markerOffset = Vector3.up / 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // クリックで Ray を飛ばす
        if (Input.GetButtonDown("Fire1"))
        {
            // カメラの位置 → マウスでクリックした場所に Ray を飛ばすように設定する
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // out パラメータで Ray の衝突情報を受け取るための変数
            // Ray を飛ばして、コライダーに当たったかどうかを戻り値で受け取る
            bool isHit = Physics.Raycast(ray, out hit); // オーバーライドがたくさんあることに注意すること
            // Ray が当たったかどうかで異なる処理をする
            if (isHit)
            {
                if(hit.collider.gameObject.tag == "")
                {

                }
                // Ray が当たった時は、当たった座標まで赤い線を引く
                Debug.DrawLine(ray.origin, hit.point, m_debugRayColorOnHit);
            }
            else
            {
                // Ray が当たらなかった場合は、Ray の方向に白い線を引く
                Debug.DrawRay(ray.origin, ray.direction * m_debugRayLength);
            }
        }
    }
}
