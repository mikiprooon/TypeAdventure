using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // シングルトンインスタンス

    private float _secondsOfTypingMode; // タイピングモードの累計時間
    private int _numOfDefeat; // 倒した敵の数
    private int _numOfCorrectType; // 正しいタイプの回数
    private int _numOfMissType; // ミスタイプの回数
    private float _totalScore; // 総合スコア


    void Awake(){
        // シングルトンパターン
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンを跨いでも破棄されない
        }
        else{
            Destroy(gameObject); // 重複したインスタンスを破棄
        }
    }

    void Start(){
        // 最初のシーンでのみ全てを初期化
        if(_totalScore == null){
            _secondsOfTypingMode = 0;
            _numOfDefeat = 0;
            _numOfCorrectType = 0;
            _numOfMissType = 0;
            _totalScore = 0;
        }

    }

    void Update(){
        // // playerがタイピングモードの時
        // if(_playerController.GetTypingModeFlag()){
        //     // その秒数を保存
        //     _secondsOfTypingMode += Time.deltaTime;
        // }

        // Debug.Log("タイピングモードの時間: " + _secondsOfTypingMode);
        // Debug.Log("倒した敵の数: " + _numOfDefeat);
    }

    // ステージシーンが読み込まれた時に全てを初期化する
    public void SetInitialize(){
        _secondsOfTypingMode = 0;
        _numOfDefeat = 0;
        _numOfCorrectType = 0;
        _numOfMissType = 0;
        _totalScore = 0;
    }

    // タイプ数/秒を計算し出力
    public float GetTypesPerSecond(){
        // 一度はタイピングした時
        if(_secondsOfTypingMode != 0){
            return _numOfCorrectType / _secondsOfTypingMode;
        }
        // 一度もタイピングしていない時
        else{
            return 0;
        }
        
    }

    // トータルスコアを計算し出力
    public float GetTotalScore(){
        // 一回はタイプした時
        if(_secondsOfTypingMode != 0){
            _totalScore = _numOfCorrectType / _secondsOfTypingMode * 10.0f
                    + _numOfDefeat * 5.0f - _numOfMissType * 5.0f;
        }
        // 一度もタイプしていない時
        else{
            _totalScore = 0;
        }
        
        
        return _totalScore;
    }


    public void AddTypingModeTime(){
        _secondsOfTypingMode += Time.deltaTime;
    }

    public void AddDefeatCount(){
        _numOfDefeat++;
    }

    public void AddCorrectType(){
        _numOfCorrectType++;
    }

    public void AddMissType(){
        _numOfMissType++;
    }

    public int GetDefeatCount()
    {
        return _numOfDefeat;
    }

    public int GetCorrectTypeCount()
    {
        return _numOfCorrectType;
    }

    public int GetMissTypeCount()
    {
        return _numOfMissType;
    }
}
