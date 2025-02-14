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
    // レベル、1でかんたん、2でふつう、3でむずかしい、4で超むずかしい、5でスペシャル
    private int _level = 0;

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
    // Boss戦かどうかPlayerControllerで判断する
    public bool GetIsBossBattle(){
        return _isBossBattle;
    }
    // 押されたボタンによってレベルを変えるため、StartSceneManagerで呼ぶ
    public void SetLevel(int level){
        _level = level;
    }
    // レベルによってEnemyGeneratorで設定する単語を変える
    public int GetLevel(){
        return _level;
    }

    // FailedSceneへ遷移
    public void LoadClearScene(){
        _isClear = false;
        _isBossBattle = false;
        SceneManager.LoadScene("ClearScene"); // ResultSceneに遷移
    }
    // FailedSceneへ遷移
    public void LoadFailedScene(){
        _isFailed = false;
        _isBossBattle = false;
        SceneManager.LoadScene("FailedScene"); // ResultSceneに遷移
    }
    // SampleSceneへ遷移
    public void LoadSampleScene(){
        GameObject scoreManager = GameObject.FindWithTag("ScoreManager");
        ScoreManager sm = scoreManager.GetComponent<ScoreManager>();
        sm.SetInitialize();
        _isBossBattle = false;
        SceneManager.LoadScene("SampleScene"); // ResultSceneに遷移
    }
    // StartSceneへ遷移
    public void LoadStartScene(){
        SceneManager.LoadScene("StartScene"); // ResultSceneに遷移
    }

    // ExplainSceneへ遷移
    public void LoadExplainScene(){
        SceneManager.LoadScene("ExplainScene"); // ResultSceneに遷移
    }

    
    
}

