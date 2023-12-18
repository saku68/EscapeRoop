using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpS : MonoBehaviour
{
    private WarpManager warpManager;
    public Transform warpTo2; // ループ先の位置
    public Transform warpTo4; // 2ステージ目
    // Start is called before the first frame update
    void Start()
    {
        warpManager = GameObject.Find("WarpManager").GetComponent<WarpManager>();
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
            // ワープ1フラグがオンの場合、プレイヤーを進行させる
            if (warpManager.warp1 == true)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                playerObject.transform.transform.position = warpTo4.position;
                playerObject.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                Debug.Log("Warp to 4 正解!!");
                warpManager.warp1 = Random.Range(0, 2) == 0;
            }
            else
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                playerObject.transform.transform.position = warpTo2.position;
                playerObject.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                Debug.Log("Warp to 2 ループや!!");
                
                
            }
        }
        
    }
    
}
