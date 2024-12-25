using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 8.0f; // 移動速度
    private float _rotationSpeed = 120.0f; // 回転速度
    private bool _typeModeFlag = false; // Trueでタイピング、Falseで移動モード
    private int _currentCharIndex = 0; // 何文字目を入力しているか

    private TextController _enemyTextController; // enemyのTextControllerへの参照

    // 効果音の設定
    public AudioClip missSound; // ミスした時
    public AudioClip attackSound; // 正しい文字を打ち込んだ時
    public AudioClip defeatSound; // 敵を倒した時
    private AudioSource _audioSource;

    void Start()
    {   
        _audioSource = GetComponent<AudioSource>(); // audioコンポーネントを取得
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

        // "Enemy"タグを持つオブジェクトを検索
        GameObject enemy = GameObject.FindWithTag("Enemy");
        // enemyの持つTextControllerを取得
        if(enemy != null){
            _enemyTextController = enemy.transform.Find("Canvas/Image").GetComponent<TextController>();
        }
        else{
            Debug.LogError("takenekoオブジェクトが見つかりませんでした。");
        }

        string answer = _enemyTextController.GetAnswerText(); // 答えを取得

        // 入力されたキーが答えと一致しているなら
        if(Input.GetKeyDown(answer[_currentCharIndex].ToString())){
            Debug.Log("正解");
            // 最後の文字を打ち終えたら
            if(_currentCharIndex + 1 >= answer.Length){
                Destroy(enemy); // 敵を消す
                _audioSource.PlayOneShot(defeatSound); // 倒した音
                _currentCharIndex = 0; // インデックスを初期化
            }
            // 最後の文字でなければ
            else{
                _audioSource.PlayOneShot(attackSound); // 攻撃した音
                _currentCharIndex++; // インデックスを+1
            }
        }
        else if(Input.anyKeyDown){
            Debug.Log("不正解");
            _audioSource.PlayOneShot(missSound); // ミスした音
        }

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
        }
    }
}
