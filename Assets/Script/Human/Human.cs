using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{

    [SerializeField] 
    private int HumanMoveInt; 
    private NavMeshAgent agent;

   //目的地の数と場所の設定
    public Transform[] points;

    //最初の目的地
    public int destPoint = 0;

    //アニメーション用
    private Animator animator;
    private WarpManager warpManager;

    // Start is called before the first frame update
    void Start()
    {
        warpManager = GameObject.Find("WarpManager").GetComponent<WarpManager>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    void GotoNextPoint() 
    {
        // //巡回の場合
        // // 地点がなにも設定されていないときに返します
        // if (points.Length == 0)
        // {
        //     return;
        // }

        // // エージェントが現在設定された目標地点に行くように設定します
        // agent.destination = points[destPoint].position;

        // // 配列内の次の位置を目標地点に設定し、
        // // 必要ならば出発地点にもどります
        // destPoint = (destPoint + 1) % points.Length;

        //４つ目で止めたい時
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
        {
            return;
        }

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;

        HumanMoveInt = HumanMoveInt + 1;
        if(HumanMoveInt  >= 4)
        {
            warpManager.humanMoveOff();
            // agent.isStopped = true;
            // agent.ResetPath(); // 現在のパスをリセット
            // agent.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // エージェントが現目標地点に近づいてきたら、
        // 次の目標地点を選択します
        if (!agent.pathPending && agent.remainingDistance < 0.5f && warpManager.HumanMove == true)
        {
        GotoNextPoint();
        }
        
        //アニメーションの切り替え
        animator.SetFloat("Move",agent.velocity.magnitude);
    }
}
