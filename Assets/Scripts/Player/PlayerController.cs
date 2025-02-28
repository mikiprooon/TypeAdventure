using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private PlayerStats _playerStats; // PlayerStatsへの参照
    private bool _isTypeMode = false; // Trueでタイピング、Falseで移動モード

    private GameObject _targetEnemy; // 現在のターゲットEnemy
    private EnemyGenerator _enemyGenerator; // EnemyGeneratorの参照

    private GameObject _targetBoss;

    private TypingSystemController _typingSystemController; // TypingSystemへの参照
    private ScoreManager _scoreManager; // ScoreManagerへの参照

    void Start()
    {
        _playerStats = PlayerStats.Instance; // シングルトンインスタンスからPlayerStatsを取得
        _playerStats.Initialize(15, 1, 8.0f);  // PlayerStatsの初期化(HP, attack, speed)

        // TypingSystemControllerへの参照
        _typingSystemController = FindObjectOfType<TypingSystemController>();
        // EnemyGeneratorへの参照
        _enemyGenerator = FindObjectOfType<EnemyGenerator>();

        _scoreManager = FindObjectOfType<ScoreManager>();

    }

    void Update()
    {
        TypeModeToggle(); // タイプモードの切り替えを処理

        if (_isTypeMode){ // タイピングモードの時
            // ボス戦の時
            if(GameManager.Instance.GetIsBossBattle()){
                // targetがいるならtypingを行う
                if(_targetEnemy != null){
                    _typingSystemController.HandleTyping();
                    transform.LookAt(new Vector3(_targetEnemy.transform.position.x, transform.position.y, _targetEnemy.transform.position.z));
                }
                // targetがいないなら探す
                else{ 
                    _targetEnemy = GameObject.FindWithTag("Boss");
                    _typingSystemController.StartTyping(_targetEnemy);
                }
            }
            // 通常の時
            else{
                // targetがいるならtypingを行う
                if(_targetEnemy != null){
                    _typingSystemController.HandleTyping();
                    Debug.Log("target: " + _targetEnemy);
                    Debug.Log("target text: " + _targetEnemy.GetComponent<EnemyStats>().GetAText());
                }
                // targetがいないなら探す
                else{ 
                    SearchClosestEnemy();
                }
                
            }
            // タイピング時間を加算
            _scoreManager.AddTypingModeTime();
            
            
        }
        else{ // 移動モードの時
        
            HandleMovement(); // 平行移動
            HandleRotation(); // 回転
        }

        Debug.Log("Player: " + transform.position);
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
            // // 最も近いEnemyの_aTextを取得して表示
            // EnemyStats enemyStats = _targetEnemy.GetComponent<EnemyStats>();
            // if (enemyStats != null){
            //     string aText = enemyStats.GetAText(); // _aTextを取得
            //     // ターゲットの方を向く
            //     transform.LookAt(new Vector3(_targetEnemy.transform.position.x, transform.position.y, _targetEnemy.transform.position.z));
            // }
            // タイピングシステムを開始
            _typingSystemController.StartTyping(_targetEnemy);
            // ターゲットの方を向く
            transform.LookAt(new Vector3(_targetEnemy.transform.position.x, transform.position.y, _targetEnemy.transform.position.z));
        }
        // targetがいないなら
        else{
            // 移動モードにする
            _isTypeMode = false;
        }
        
    }

    // タイピングと移動モードを切り替える
    private void TypeModeToggle(){
        if (Input.GetKeyDown(KeyCode.Space)){
            _isTypeMode = !_isTypeMode; // TrueとFalseを切り替える
            if (!_isTypeMode){ // 移動モードになった時 
                _targetEnemy = null; // targetを初期化
            }
            
        }
    }

    // 移動処理
    private void HandleMovement(){
        Vector3 moveDirection = Vector3.zero;
        // Eで前、Wで後ろ、Fで右、Aで左移動
        if (Input.GetKey(KeyCode.E)) moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.W)) moveDirection -= transform.forward;
        if (Input.GetKey(KeyCode.F)) moveDirection += transform.right;
        if (Input.GetKey(KeyCode.A)) moveDirection -= transform.right;

        transform.position += moveDirection.normalized * _playerStats.GetMoveSpeed() * Time.deltaTime;
    }

    // 回転処理
    private void HandleRotation(){
        // Oで右、Iで左回転
        if (Input.GetKey(KeyCode.I)){
            transform.Rotate(0, -_playerStats.GetRotationSpeed() * Time.deltaTime, 0);
        } 
        else if (Input.GetKey(KeyCode.O)){
            transform.Rotate(0, _playerStats.GetRotationSpeed() * Time.deltaTime, 0);
        }
        // if (Input.GetKey(KeyCode.A)) transform.Rotate(0, -1f, 0);
        // else if (Input.GetKey(KeyCode.F)) transform.Rotate(0, 1f, 0);
    }

    // targetの消滅を外部から設定できるようにする
    public void DeleteTarget(){
        _targetEnemy = null;
    }

    // タイピングモードか否かを取得
    // ScoreMangerで使用
    public bool GetIsTypeMode(){
        return _isTypeMode;
    }

    public Vector3 GetTargetTextPosition(){
        if(GameManager.Instance.GetIsBossBattle()){
            if(_targetBoss != null){
                return _targetBoss.GetComponentInChildren<Canvas>().transform.position;
            }
            else{
                return transform.position;
            }
        }
        else{
            if(_targetEnemy != null){
                return _targetEnemy.GetComponentInChildren<Canvas>().transform.position;
            }
            else{
                return transform.position;
            }
        }
    }
}
