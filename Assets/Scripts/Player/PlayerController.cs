using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private PlayerStats _playerStats; // PlayerStatsへの参照
    private bool _typeModeFlag = false; // Trueでタイピング、Falseで移動モード

    private GameObject _targetEnemy; // 現在のターゲットEnemy
    private bool _isLookTarget = false; // ターゲットを持っているならtrue、いないならfalse
    private EnemyGenerator _enemyGenerator; // EnemyGeneratorの参照

    private TypingSystemController _typingSystemController; // TypingSystemへの参照
    private ScoreManager _scoreManager; // ScoreManagerへの参照

    void Start()
    {
        _playerStats = PlayerStats.Instance; // シングルトンインスタンスからPlayerStatsを取得
        _playerStats.Initialize(10, 1, 8.0f);  // PlayerStatsの初期化(HP, attack, speed)

        // TypingSystemControllerへの参照
        _typingSystemController = FindObjectOfType<TypingSystemController>();
        // EnemyGeneratorへの参照
        _enemyGenerator = FindObjectOfType<EnemyGenerator>();

        _scoreManager = FindObjectOfType<ScoreManager>();

    }

    void Update()
    {
        TypeModeToggle(); // タイプモードの切り替えを処理

        if (_typeModeFlag){ // タイピングモードの時
            // targetがいるならtypingを行う
            if(_targetEnemy != null){
                _typingSystemController.HandleTyping();
            }
            // targetがいないなら探す
            else{ 
                SearchClosestEnemy();
            }
            // タイピング時間を加算
            _scoreManager.AddTypingModeTime();
            
        }
        else{ // 移動モードの時
        
            HandleMovement(); // 平行移動
            HandleRotation(); // 回転
        }
    }

    // Enemyを倒した時、またはtabキーを押した時にターゲットを変える
    public void ChangeEnemy(){
        SearchClosestEnemy(); // 最も近いEnemyを探す
        
    }


    // ターゲットとなるEnemyを取得する
    public void SearchClosestEnemy(){
        // 全Enemyの情報を取得
        List<GameObject> _enemies = new List<GameObject>();
        _enemies = _enemyGenerator.GetAllEnemies(); 
        float closestDistance = 20f; // 距離20以内ならtargetとする
        float distance = 0f; // 各Enemyとの距離
        
        foreach (GameObject enemy in _enemies){
            distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= closestDistance){ // 20より近い中で最も近いEnemyを探す
                _targetEnemy = enemy; // targetに設定
                closestDistance = distance; // 最も近い距離を更新
            }
        }
        // targetがいるなら
        if(_targetEnemy != null){
            // 最も近いEnemyの_aTextを取得して表示
            EnemyStats enemyStats = _targetEnemy.GetComponent<EnemyStats>();
            if (enemyStats != null){
                string aText = enemyStats.GetAText(); // _aTextを取得
                // ターゲットの方を向く
                transform.LookAt(new Vector3(_targetEnemy.transform.position.x, transform.position.y, _targetEnemy.transform.position.z));
            }
            // タイピングシステムを開始
            _typingSystemController.StartTyping(_targetEnemy);
        }
        
    }

    // タイピングと移動モードを切り替える
    private void TypeModeToggle(){
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
            _typeModeFlag = !_typeModeFlag; // TrueとFalseを切り替える
            if (!_typeModeFlag){ // 移動モードになった時 
                _targetEnemy = null; // targetを初期化
            }
            
        }
    }

    // 移動処理
    private void HandleMovement(){
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.DownArrow)) moveDirection -= transform.forward;
        if (Input.GetKey(KeyCode.RightArrow)) moveDirection += transform.right;
        if (Input.GetKey(KeyCode.LeftArrow)) moveDirection -= transform.right;

        transform.position += moveDirection.normalized * _playerStats.GetMoveSpeed() * Time.deltaTime;
    }

    // 回転処理
    private void HandleRotation(){
        if (Input.GetKey(KeyCode.A)) transform.Rotate(0, -_playerStats.GetRotationSpeed() * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.S)) transform.Rotate(0, _playerStats.GetRotationSpeed() * Time.deltaTime, 0);
    }

    // targetの消滅を外部から設定できるようにする
    public void DeleteTarget(){
        _targetEnemy = null;
    }

    // タイピングモードか否かを取得
    // ScoreMangerで使用
    public bool GetTypingModeFlag(){
        return _typeModeFlag;
    }
}
