using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    // Textに触るための変数
    [SerializeField] TextMeshProUGUI aTmpText; // ローマ字, 打つ内容
    [SerializeField] TextMeshProUGUI qTmpText; // 漢字, 問題文
    [SerializeField] TextMeshProUGUI mTmpText; // 読み方, 意味

    // 答えを保存しておく
    private string _aText; // ローマ字
    private string _qText; // 問題文
    private string _mText; // 読み方

    // 親オブジェクトのEnemyStatsを取得
    private EnemyStats _enemyStats;

    private Camera _mainCamera; // プレイヤのカメラ

    private void Awake(){
        // 親オブジェクトにあるEnemyStatsを取得
        _enemyStats = GetComponentInParent<EnemyStats>();
        Debug.Log("Awake()時点でのaText: " + _enemyStats.GetAText());
        

        if (_enemyStats == null){
            Debug.LogError("親オブジェクトにEnemyStatsが見つかりません！");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Imageをカメラに向けると反転するので、あらかじめ180度回す
        //transform.localScale = new Vector3 (-1, 1, 1); 
        //_mainCamera = Camera.main; // メインカメラを取得
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(_mainCamera.transform); //Imageが常にカメラの方を向くようにする
    }

    // 正解した時に文字を灰色にする
    public void ChangeTextColorBasic(){
        aTmpText.text = "<color=#000000>" + _aText + "</color>";
    }

    // 正解した時に文字を灰色にする
    public void ChangeTextColorCorrect(int currentCharIndex){
        aTmpText.text = "<color=#6A6A6A>" + _aText.Substring(0, currentCharIndex) + "</color>"
                        + _aText.Substring(currentCharIndex);
    }

    // 間違えた時に文字を赤くする
    public void ChangeTextColorWrong(int currentCharIndex){
        aTmpText.text = "<color=#6A6A6A>" + _aText.Substring(0, currentCharIndex) + "</color>"
                        + "<color=#FF0000>" + _aText.Substring(currentCharIndex, 1) + "</color>"
                        + _aText.Substring(currentCharIndex + 1);
    }

    // 現在の答えを返すゲッター
    public string GetAnswerText(){
        return _aText;
    }

    public void SetText(){
        //答え用の変数に保存
        _aText = _enemyStats.GetAText();
        _qText = _enemyStats.GetQText(); 
        _mText = _enemyStats.GetMText(); 
        // TMPに答え、問題、読み方を設定
        aTmpText.text = _aText; 
        qTmpText.text = _qText; 
        mTmpText.text = _mText; 
    }
}
