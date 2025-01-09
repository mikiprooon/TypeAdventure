using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // プレイ中か否か
    private bool _isBossBattle = false;
    // ゲームクリアでtrue
    private bool _isClear = false;
    // ゲームオーバーでtrue
    private bool _isFailed = false;

    public static GameManager Instance; // シングルトンパターン

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    void Update(){
        if(_isClear){
            LoadClearScene();
        }
        else if(_isFailed){
            LoadFailedScene();
        }

    }

    // playerのHPが0の時にPlayerStatsで呼び出す
    public void PlayerIsDeath(){
        _isFailed = true;
    }
    // BossEnemyのHPが0の時にBossStatsで呼び出す
    public void BossIsDeath(){
        _isClear = true;
    }
    // Boss戦になったらBossBattleManagerで呼び出す
    public void StartBossBattle(){
        _isBossBattle = true;
    }
    // FailedSceneへ遷移
    public void LoadClearScene(){
        _isClear = false;
        SceneManager.LoadScene("ClearScene"); // ResultSceneに遷移
    }
    // FailedSceneへ遷移
    public void LoadFailedScene(){
        _isFailed = false;
        SceneManager.LoadScene("FailedScene"); // ResultSceneに遷移
    }
    // SampleSceneへ遷移
    public void LoadSampleScene(){
        GameObject scoreManager = GameObject.FindWithTag("ScoreManager");
        ScoreManager sm = scoreManager.GetComponent<ScoreManager>();
        sm.SetInitialize();
        SceneManager.LoadScene("SampleScene"); // ResultSceneに遷移
    }
    // StartSceneへ遷移
    public void LoadStartScene(){
        SceneManager.LoadScene("StartScene"); // ResultSceneに遷移
    }

    public bool GetIsBossBattle(){
        return _isBossBattle;
    }
    
}

