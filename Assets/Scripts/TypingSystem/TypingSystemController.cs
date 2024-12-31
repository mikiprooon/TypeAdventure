using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// タイピングの正誤を判定する
public class TypingSystemController : MonoBehaviour
{   
    private string _answer; // 打ちこむ問題
    private int _currentCharIndex; // 現在何文字目か

    private GameObject _targetEnemy; // ターゲットのEnemy
    private TextController _targetEnemyTextController; // ターゲットの持つTextControlerへの参照
    
    [SerializeField] private GameObject _player; //Player
    private PlayerController _playerController; //playerControllerへの参照


    void Start(){
        //PlayerControllerへの参照を取得
        _playerController = _player.GetComponent<PlayerController>(); 
    }
    // タイピング開始時に呼び出すメソッド
    public void StartTyping(GameObject targetEnemy){
        _targetEnemy = targetEnemy; // ターゲットのオブジェクトを取得
        // ターゲットのTextControllerを取得
        _targetEnemyTextController = _targetEnemy.transform.Find("Canvas/Image").GetComponent<TextController>();
        // ターゲットの正解文を取得
        _answer = _targetEnemyTextController.GetAnswerText();
        _currentCharIndex = 0; // 文字数を初期化
        _targetEnemyTextController.ChangeTextColorBasic();
    }

    // タイピングの処理
    public void HandleTyping(){
        // ctrlキーが押されている場合、タイピング処理をスキップ
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)){
            return;
        }

        Debug.Log("何文字目: " + _currentCharIndex);
        // 入力されたキーが答えと一致しているなら
        if (Input.GetKeyDown(_answer[_currentCharIndex].ToString())){
            InputCorrecKey(); // 正しい時の処理
        }
        // 間違えた入力なら
        else if (Input.anyKeyDown){
            InputWrongKey(); // 誤った時の処理
        }
    }

    // 正しいキーの時の処理
    private void InputCorrecKey(){
        Debug.Log("正解");
        // 攻撃音
        AudioManager.Instance.PlaySound(AudioManager.Instance.attackSound);
        // 最後の文字を打ち終えたら
        if (_currentCharIndex + 1 >= _answer.Length){
            
            EnemyStats _enemyStats = _targetEnemy.GetComponent<EnemyStats>();
            _enemyStats.DamageToEnemy(1);

            // インデックスと解答を初期化
            _currentCharIndex = 0; 
            _answer = "  "; 
            
        }
        // 最後の文字でなければ
        else{
            
            _currentCharIndex++; // インデックスを+1
            // 正解した文字を灰色にする
            _targetEnemyTextController.ChangeTextColorCorrect(_currentCharIndex);
        }
    }

    // 間違ったキーの時の処理
    private void InputWrongKey(){
        Debug.Log("不正解");
        // ミス音
        AudioManager.Instance.PlaySound(AudioManager.Instance.missSound);
        // 間違えた字を赤くする
        _targetEnemyTextController.ChangeTextColorWrong(_currentCharIndex);
    }
}
