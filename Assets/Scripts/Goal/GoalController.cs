using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private GameManager _gameManager;

    void Start(){
    }
    // Playerと衝突したら、
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            if(GameManager.Instance.GetSceneNumber() == 1){
                GameManager.Instance.Load2ndScene();
            }
            else if(GameManager.Instance.GetSceneNumber() == 2){
                GameManager.Instance.Load3rdScene();
            }
            else if(GameManager.Instance.GetSceneNumber() == 3){
                GameManager.Instance.LoadResultScene();
            }
            
        }
    }
}

