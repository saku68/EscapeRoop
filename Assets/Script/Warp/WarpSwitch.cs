using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSwitch : MonoBehaviour
{
    private WarpManager warpManager;
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
        if (other.CompareTag("Player"))
        {
            // Debug.Log("切り替えスイッチに接触した");
            if (warpManager.warpSwitch == true)
            {
                warpManager.SwitchWarp();
                warpManager.humanMoveOn();
            }
        }
    }
}
