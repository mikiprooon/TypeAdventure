using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private static PlayerStats _instance; // シングルトンインスタンス
    public static PlayerStats Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<PlayerStats>();
                if (_instance == null) {
                    GameObject obj = new GameObject("PlayerStats");
                    _instance = obj.AddComponent<PlayerStats>();
                }
            }
            return _instance;
        }
    }

    private int _hp; // HP
    private float _moveSpeed; // 移動速度
    private float _rotationSpeed = 120.0f; // 回転速度

    // 初期化メソッド
    public void Initialize(int hp, float moveSpeed){
        _hp = hp;       // HPを設定
        _moveSpeed = moveSpeed; // スピードを設定
    }

    // Start is called before the first frame update
    void Start()
    {
        // シングルトンがすでに初期化されている場合はDestroyし、重複を防ぐ
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject); // シーンを跨いでも破棄されないようにする
        }
        
    }

    // Update is called once per frame
    void Update(){
        // HPが0以下でゲームオーバー
        if(_hp <= 0){
            Debug.Log("GameOver");
        }
    }


    // playerの被ダメージ
    public void DamageToPlayer(int damage){
        _hp -= damage; // damageの分HPを減らす
        Debug.Log("HP: "+ _hp);
    }

    // プレイヤーのHPを取得
    public int GetHP() {
        return _hp;
    }

    // プレイヤーのHPを設定
    public void SetHP(int hp) {
        _hp = hp;
    }

    // プレイヤーの速度を取得
    public float GetMoveSpeed() {
        return _moveSpeed;
    }

    // プレイヤーの速度を設定
    public void SetMoveSpeed(float moveSpeed) {
        _moveSpeed = moveSpeed;
    }

    // プレイヤーの回転速度を取得
    public float GetRotationSpeed() {
        return _rotationSpeed;
    }

    // プレイヤーの回転速度を設定
    public void SetRotationSpeed(float rotationSpeed) {
        _rotationSpeed = rotationSpeed;
    }
}
