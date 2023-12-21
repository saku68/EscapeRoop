using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
    public bool warpSwitch ; // 切り替え制限フラグ
    public bool warp1 ; // 脱ループフラグ
    public bool warp2 ; // 脱ループフラグ 
    
    // [SerializeField]
    // private  GameObject warpswitch1;
    // [SerializeField]
    // private  GameObject warpswitch2;


    // Start is called before the first frame update
    void Start()
    {
        warp1 = false;
        warp2 = false;
        warpSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // // プレイヤーキャラクターが接触したら
        // if (other.CompareTag("Player") && other.gameObject == warpswitch1)
        // {
        //     warp2 = Random.Range(0, 2) == 0; // 0か1をランダムに選択し、0ならFalse、1ならTrueを設定する
        // }
        // // プレイヤーキャラクターが接触したら
        // if (other.CompareTag("Player") && other.gameObject == warpswitch2)
        // {
        //     warp1 = Random.Range(0, 2) == 0; // 0か1をランダムに選択し、0ならFalse、1ならTrueを設定する
        // }
        

        //プレイヤーがどちらかに接触したらどちらかをオンにする
        // if (other.CompareTag("Player") && (other.gameObject == warpswitch1 || other.gameObject == warpswitch2))
        // {
        //     Debug.Log("接触はした");
        //     if (warpSwitch == true)
        //     {
        //         Debug.Log("trueも検知した");
        //         // warpswitch1 または warpswitch2 に接触したら、ランダムにどちらかのフラグをオンにする
        //         bool randomFlag = Random.Range(0, 2) == 0; // 0か1をランダムに選択し、0ならFalse、1ならTrueを設定する
        //         // warpswitch1 に接触した場合は warp2 を、warpswitch2 に接触した場合は warp1 を設定する
        //         if (other.gameObject == warpswitch1)
        //         {
        //         warp2 = randomFlag;
        //         warp1 = !warp2;
        //         warpSwitch = false;
        //         Debug.Log("warpswitch 切り替え");
        //         }   
        //         else if (other.gameObject == warpswitch2)
        //         {
        //         warp1 = randomFlag;
        //         warp2 = !warp1;
        //         warpSwitch = false;
        //         Debug.Log("warpswitch 切り替え");
        //         }
        //     }
        // }

            //もう直接貼り付けよう
    }
    public void SwitchWarp()
    {
        bool randomFlag = Random.Range(0, 2) == 0; // 0か1をランダムに選択し、0ならFalse、1ならTrueを設定する
        warp2 = randomFlag;
        warp1 = !warp2;
        warpSwitch = false;
        Debug.Log("warpswitch 切り替え");
    }
    public void Warpswi()
    {
        warpSwitch = true;
        warp1 = false;
        warp2 = false;
    }

}
