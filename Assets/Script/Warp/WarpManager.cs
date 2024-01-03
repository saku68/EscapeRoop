using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
    public bool gimmickSwitch = false;
    private Human human;
    //最初の人間の目的地
    public int destPoint = 0;
    //目的地の数と場所の設定
    public Transform[] points;

    // public GameObject humanPrefab; // 生成する人間のプレハブ
    public Transform humanSpawnPoint1;   // 人間の生成先の位置
    public Transform humanSpawnPoint2;   // 人間の生成先の位置
    // [SerializeField]
    // private GameObject spawnedHuman; // 生成された人間の参照を保持する変数
    public int HumanMoveInt; 
    public bool HumanMove = false;
    public bool HumanMove1 = true;
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
        human = GameObject.Find("Basic_BanditPrefab").GetComponent<Human>();
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
    
    //ワープの正誤入れ替え
    public void SwitchWarp()
    {
        bool randomFlag = Random.Range(0, 2) == 0; // 0か1をランダムに選択し、0ならFalse、1ならTrueを設定する
        warp2 = randomFlag;
        warp1 = !warp2;
        warpSwitch = false;
        Debug.Log("warpswitch 切り替え");
    }

    //ワープスイッチのリセット
    public void Warpswi()
    {
        warpSwitch = true;
        warp1 = false;
        warp2 = false;
    }
    
    public void humanMoveOn()
    {
        HumanMove = true;
        HumanMoveInt = 0;
    }
    public void humanMoveOff()
    {
        HumanMove = false;
    }
    public void humanInt()
    {
        HumanMoveInt = HumanMoveInt + 1;
    }
    public void humanMoveSwitch1()
    {
        destPointReset1();
        HumanMove1 = true;
        human.humanAgentReset();
    }
    public void humanMoveSwitch2()
    {
        destPointReset2();
        HumanMove1 = false;
        human.humanAgentReset();
    }

    // public void SpawnHumanAtSpawnPoint1()
    // {
    //     spawnedHuman = Instantiate(humanPrefab, humanSpawnPoint1.position, humanSpawnPoint1.rotation);
    //     // 生成されたオブジェクトの持つ全てのコンポーネントを有効にする
    //     Behaviour[] behaviours = spawnedHuman.GetComponents<Behaviour>();
    //     foreach (Behaviour behaviour in behaviours)
    //     {
    //     behaviour.enabled = true;
    //     }
    // }
    // public void SpawnHumanAtSpawnPoint2()
    // {
    //     spawnedHuman = Instantiate(humanPrefab, humanSpawnPoint2.position, humanSpawnPoint2.rotation);
    //     // 生成されたオブジェクトの持つ全てのコンポーネントを有効にする
    //     Behaviour[] behaviours = spawnedHuman.GetComponents<Behaviour>();
    //     foreach (Behaviour behaviour in behaviours)
    //     {
    //     behaviour.enabled = true;
    //     }
    // }
    // // 生成された人間を削除する関数
    // public void DestroyHuman()
    // {
    //     GameObject HumanObject = GameObject.FindGameObjectWithTag("Human");
    //     if (HumanObject != null)
    //     {
    //         Destroy(HumanObject);
    //     }
    // }
    // public void DestroySpawnedHuman()
    // {
    //     if (spawnedHuman != null)
    //     {
    //         Destroy(spawnedHuman);
    //     }
    // }

    //人間の歩く方向
    public void destPointSet()
    {
        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        if (HumanMove1 == true)
        {
        destPoint = (destPoint + 1) % points.Length;
        }
        if (HumanMove1 == false)
        {
        destPoint = (destPoint > 0) ? destPoint - 1 : points.Length - 1;
        }
    }
    public void destPointReset1()
    {
        destPoint = 0;
    }
    public void destPointReset2()
    {
        destPoint = 3;
    }
    public void warpHuman1()
    {
        GameObject humanObject = GameObject.FindGameObjectWithTag("Human");
        humanObject.transform.transform.position = humanSpawnPoint1.position;
    }
    public void warpHuman2()
    {
        GameObject humanObject = GameObject.FindGameObjectWithTag("Human");
        humanObject.transform.transform.position = humanSpawnPoint2.position;
    }

    //ギミックの切り替え
    public void gimmickSwitchOn()
    {
        gimmickSwitch = true;
    }
    public void gimmickSwitchOff()
    {
        gimmickSwitch = false;
    }

}
