using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{   
    // Textに触るための変数
    [SerializeField] TextMeshProUGUI aText; // ローマ字, 打つ内容
    [SerializeField] TextMeshProUGUI qText; // 漢字, 問題文
    [SerializeField] TextMeshProUGUI mText; // 読み方, 意味

    // 問題, 解凍, 読み方を保存するstring配列
    private string[] _answer = {"mondai", "kaitou", "yomikata"};
    private string[] _question = {"問題", "解答", "読み方"};
    private string[] _meaning = {"もんだい", "かいとう", "よみかた"};
    private int _qNum; // 何番目の問題か

    private Camera _mainCamera; // プレイヤのカメラ

    void Start()
    {   
        // Imageをカメラに向けると反転するので、あらかじめ180度回す
        transform.localScale = new Vector3 (-1, 1, 1); 
        CreateQuestion(); // 問題を表示

        _mainCamera = Camera.main; // メインカメラを取得
        
        
    }

    void Update()
    {
        transform.LookAt(_mainCamera.transform); //Imageが常にカメラの方を向くようにする
    }

    // 問題を作成・表示
    void CreateQuestion(){
        //問題番号を決める
        _qNum = Random.Range(0, _question.Length); 
        // 答え、問題、読み方を設定
        aText.text = _answer[_qNum]; 
        qText.text = _question[_qNum]; 
        mText.text = _meaning[_qNum]; 
    }

    // 現在の答えを返すゲッター
    public string GetAnswerText(){
        return aText.text;
    }
}
