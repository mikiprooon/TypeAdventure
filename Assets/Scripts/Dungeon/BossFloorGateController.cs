using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFloorGateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GetIsBossBattle()){
            transform.localPosition = new Vector3(0f, 3.358393f, -14.8f);
        }
        
    }
}
