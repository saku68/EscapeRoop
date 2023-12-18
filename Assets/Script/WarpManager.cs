using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
    public bool warp1 ; // ワープフラグ
    public bool warp2 ; // ワープフラグ 

    // Start is called before the first frame update
    void Start()
    {
        warp1 = Random.Range(0, 2) == 0; // 0か1をランダムに選択し、0ならFalse、1ならTrueを設定する
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
