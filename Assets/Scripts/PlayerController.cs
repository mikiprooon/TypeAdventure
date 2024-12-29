using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 8.0f; // 移動速度
    private float _rotationSpeed = 120.0f; // 回転速度
    private bool _typeModeFlag = false; // Trueでタイピング、Falseで移動モード

    private TypingSystemController _typingSystemController; // TypingSystemControllerの参照
    private GameObject _targetEnemy; // 現在のターゲットEnemy
    private EnemyGenerator _enemyGenerator; // EnemyGeneratorの参照

    void Start()
    {
        // TypingSystemControllerを取得
        _typingSystemController = FindObjectOfType<TypingSystemController>();
        // TypingSystemControllerを取得
        _enemyGenerator = FindObjectOfType<EnemyGenerator>();

        // // 最も近い位置にいるenemyをtargetに設定
        // SearchClosestEnemy();
        // // タイピングシステムの開始
        // _typingSystemController.StartTyping(_targetEnemy);
    }

    void Update()
    {
        HandleTypeModeToggle(); // タイプモードの切り替えを処理

        if (_typeModeFlag) // タイピングモードの時
        {
            // タイピング処理をTypingSystemControllerに委譲
            _typingSystemController.HandleTyping();
        }
        else // 移動モードの時
        {
            HandleMovement(); // 平行移動
            HandleRotation(); // 回転
        }
    }

    // ターゲットとなるEnemyを取得する
    private void SearchClosestEnemy(){
        List<GameObject> _enemies = new List<GameObject>();
        _enemies = _enemyGenerator.GetAllEnemies();
        float closestDistance = 10000f;
        float distance = 0f;

        foreach (GameObject enemy in _enemies){
            distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance <= 20.0f){
                _targetEnemy = enemy; // targetに設定
                closestDistance = Vector3.Distance(transform.position, enemy.transform.position);
            }
        }
    }

    // タイピングと移動モードを切り替える
    private void HandleTypeModeToggle(){
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
            _typeModeFlag = !_typeModeFlag; // TrueとFalseを切り替える
            Debug.Log(_typeModeFlag);
            if (_typeModeFlag){ // タイピングモードになった時 
                // targetを探す
                SearchClosestEnemy();
                // タイピングシステムを開始
                _typingSystemController.StartTyping(_targetEnemy);
                Debug.Log(_targetEnemy);
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

        transform.position += moveDirection.normalized * _moveSpeed * Time.deltaTime;
    }

    // 回転処理
    private void HandleRotation(){
        if (Input.GetKey(KeyCode.A)) transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.S)) transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
