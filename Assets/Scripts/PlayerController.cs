using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 8.0f; // 移動速度
    private float _rotationSpeed = 120.0f; // 回転速度
    private bool _typeModeFlag = false; // Trueでタイピング、Falseで移動モード
    private int _currentCharIndex = 0; // 何文字目を入力しているか

    private TextController _enemyTextController; // enemyのTextControllerへの参照

    private GameObject _enemy;
    private string _answer;
    void Start()
    {   
        // enemyを設定
        _enemy = GameObject.FindWithTag("Enemy");
        // enemyの持つTextControllerを設定
        _enemyTextController = _enemy.transform.Find("Canvas/Image").GetComponent<TextController>();
        // 答えとなる文字を取得
        _answer = _enemyTextController.GetAnswerText();
        Debug.Log(_answer);
    }
    void Update()
    {
        HandleTypeModeToggle(); // タイプモードの切り替えを処理

        if(_typeModeFlag){ //タイピングモードの時
            //Debug.Log("タイプモード");
            HandleTyping();
        }
        else{ //移動モードの時
            HandleMovement(); // 平行移動
            HandleRotation(); // 回転
        }

    }

    // playerのタイピング処理
    private void HandleTyping(){

        // ctrlキーが押されている場合、タイピング処理をスキップ
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)){
            return;
        }

        //
        // "Enemy"タグを持つオブジェクトを検索
        //GameObject enemy = GameObject.FindWithTag("Enemy");
        // enemyの持つTextControllerを取得
        // if(enemy != null){
        //     _enemyTextController = enemy.transform.Find("Canvas/Image").GetComponent<TextController>();
        // }
        // else{
        //     Debug.LogError("takenekoオブジェクトが見つかりませんでした。");
        // }
        //string answer = _enemyTextController.GetAnswerText(); // 答えを取得
        
        // 入力されたキーが答えと一致しているなら
        if(Input.GetKeyDown(_answer[_currentCharIndex].ToString())){
            InputCorrecKey(); //正しい時の処理
        }
        // 間違えた入力なら
        else if(Input.anyKeyDown){
            InputWrongKey(); //誤った時の処理
        }

    }

    // private string GetAnswerText(){
    //     // "Enemy"タグを持つオブジェクトを検索
    //     //GameObject enemy = GameObject.FindWithTag("Enemy");
    //     // enemyの持つTextControllerを取得
    //     if(_enemy != null){
    //         _enemyTextController = _enemy.transform.Find("Canvas/Image").GetComponent<TextController>();
    //     }
    //     else{
    //         Debug.LogError("takenekoオブジェクトが見つかりませんでした。");
    //     }
    //     return _enemyTextController.GetAnswerText(); // 答えを取得
    // }

    // 正しいキーの時の処理
    private void InputCorrecKey(){
        Debug.Log("正解");
            // 最後の文字を打ち終えたら
            if(_currentCharIndex + 1 >= _answer.Length){
                Destroy(_enemy); // 敵を消す
                // 敵を倒した音
                AudioController.Instance.PlaySound(AudioController.Instance.defeatSound);
                _currentCharIndex = 0; // インデックスを初期化
            }
            // 最後の文字でなければ
            else{
                // 攻撃音
                AudioController.Instance.PlaySound(AudioController.Instance.attackSound);
                _currentCharIndex++; // インデックスを+1
                // 正解した文字を灰色にする
                _enemyTextController.ChangeTextColorCorrect(_currentCharIndex); 
            }
    }

    // 間違ったキーの時の処理
    private void InputWrongKey(){
        Debug.Log("不正解");
        // ミス音
        AudioController.Instance.PlaySound(AudioController.Instance.missSound);
        // 間違えた字を赤くする
        _enemyTextController.ChangeTextColorWrong(_currentCharIndex); 
    }

    // playerの移動処理
    private void HandleMovement(){
        // 移動方向の初期化
        Vector3 moveDirection = Vector3.zero;

        // キー入力に応じて移動方向を決定
        if(Input.GetKey(KeyCode.UpArrow)){
            moveDirection += transform.forward; // ↑キーで前進
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            moveDirection -= transform.forward; // ↓キーで後退
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            moveDirection += transform.right; // →キーで右移動
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            moveDirection -= transform.right; // ←キーで左移動
        }

        // キャラクタを移動
        transform.position += moveDirection.normalized * _moveSpeed * Time.deltaTime;
    }

    // Playerの回転処理
    private void HandleRotation(){
        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0); // Aキーで左回転
        }
        else if (Input.GetKey(KeyCode.S)){
            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0); // Sキーで右回転
        }
    }

    // タイピングと移動モードを切り替える
    private void HandleTypeModeToggle(){   
        // ctrlキーでモードを切り替え
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
            _typeModeFlag = !_typeModeFlag; // TrueとFalseを切り替える
            Debug.Log(_typeModeFlag);
            _currentCharIndex = 0; // 文字は最初から入力させる
            if(_typeModeFlag){ // タイピングモードになった時に答えを取得
                // enemyを設定
                _enemy = GameObject.FindWithTag("Enemy");
                // enemyの持つTextControllerを設定
                _enemyTextController = _enemy.transform.Find("Canvas/Image").GetComponent<TextController>();
                // 答えを設定
                _answer = _enemyTextController.GetAnswerText();
            }
        }
    }

    // ターゲットを決める 
}
