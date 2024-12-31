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

    // 問題, 解凍, 読み方を保存するstring配列
    private string[] _answer = {"mondai", "kaitou", "yomikata"};
    private string[] _question = {"問題", "解答", "読み方"};
    private string[] _meaning = {"もんだい", "かいとう", "よみかた"};
    private int _qNum; // 何番目の問題か

    // 答えを保存しておく
    private string _aText; // ローマ字
    private string _qText; // 問題文
    private string _mText; // 読み方

    private Camera _mainCamera; // プレイヤのカメラ

    void Start()
    {   
        // Imageをカメラに向けると反転するので、あらかじめ180度回す
        transform.localScale = new Vector3 (-1, 1, 1); 
        //CreateQuestion(); // 問題を表示

        _mainCamera = Camera.main; // メインカメラを取得
        
        
    }

    void Update()
    {
        transform.LookAt(_mainCamera.transform); //Imageが常にカメラの方を向くようにする
    }

    // // 問題を作成・表示
    // private void CreateQuestion(){
    //     //問題番号を決める
    //     _qNum = Random.Range(0, _question.Length); 

    //     //答え用の変数に保存
    //     _aText = _answer[_qNum];
    //     _qText = _question[_qNum]; 
    //     _mText = _meaning[_qNum]; 
    //     // TMPに答え、問題、読み方を設定
    //     aTmpText.text = _answer[_qNum]; 
    //     qTmpText.text = _question[_qNum]; 
    //     mTmpText.text = _meaning[_qNum]; 
    // }

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

    public void SetQuestion(string aText, string qText, string mText){
        //答え用の変数に保存
        _aText = aText;
        _qText = qText; 
        _mText = mText; 
        // TMPに答え、問題、読み方を設定
        aTmpText.text = aText; 
        qTmpText.text = qText; 
        mTmpText.text = mText; 
    }
}
