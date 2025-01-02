using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // シングルトンパターン

    private int _sceneNumber = 1; // シーンの番号

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    // 2ndSceneへ遷移
    public void Load2ndScene(){
        _sceneNumber = 2;
        Debug.Log("Playerが2ndに到達しました！");
        SceneManager.LoadScene("SecondStageScene"); // ResultSceneに遷移
    }

    // 3rdSceneへ遷移
    public void Load3rdScene(){
        _sceneNumber = 3;
        Debug.Log("Playerが3rdに到達しました！");
        SceneManager.LoadScene("ThirdStageScene"); // ResultSceneに遷移
    }

    // ResultSceneへ遷移
    public void LoadResultScene(){
        Debug.Log("PlayerがGoalに到達しました！");
        SceneManager.LoadScene("ResultScene"); // ResultSceneに遷移
    }

    public int GetSceneNumber(){
        return _sceneNumber;
    }
}

