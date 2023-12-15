using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpF : MonoBehaviour
{
    public bool warp1 = false; // ワープフラグ
    public GameObject warp2; // Warp2のGameObjectをInspectorから指定
    public Transform warpTo2; // 移動先のターゲット位置をInspectorから設定
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーキャラクターが接触したら
        if (other.CompareTag("Player"))
        {
            // ワープ2フラグをオンにする
            WarpS warpS = warp2.GetComponent<WarpS>();
            warpS.warp2 = true;
            Debug.Log("Warp2 flag is ON!");

            // ワープ1フラグがオンの場合、プレイヤーを移動させる
            if (warp1 == true)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                playerObject.transform.transform.position = warpTo2.position;
                playerObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                warp1 = false;
                Debug.Log("Warp to 1!!");
            
            }
        }
    }
}
