using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpS : MonoBehaviour
{
    public bool warp2 = false; // ワープフラグ
    public GameObject warp1; // Warp1のGameObjectをInspectorから指定
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
            // ワープ１フラグをオンにする
            WarpF warpF = warp1.GetComponent<WarpF>();
            warpF.warp1 = true;
            Debug.Log("Warp1 flag is ON!");

            // ワープ2フラグがオンの場合、プレイヤーを移動させる
            if (warp2 == true)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                playerObject.transform.transform.position = warpTo2.position;
                playerObject.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                warp2 = false;
                Debug.Log("Warp to 2!!");
            
            }
        }
        
    }
    
}
