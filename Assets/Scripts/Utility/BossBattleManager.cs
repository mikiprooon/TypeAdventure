using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleManager : MonoBehaviour
{   
    private GameObject _bossEnemy; // Bossへの参照
    private BossController _bossController; // BossControllerへの参照

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_bossEnemy == null){
            _bossEnemy = GameObject.FindWithTag("Boss");
            _bossController = _bossEnemy.GetComponent<BossController>();
        }
        Debug.Log("IsBossBattle: " + GameManager.Instance.GetIsBossBattle());
        Debug.Log("bossEnemy: " +  _bossEnemy);
        Debug.Log("bossController: " +  _bossController);
        Debug.Log("IsChasing: " +  _bossController.GetIsChasing());
        if(!GameManager.Instance.GetIsBossBattle() && _bossController.GetIsChasing()){
            GameManager.Instance.StartBossBattle();
        }
        
    }
}
