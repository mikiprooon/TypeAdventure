using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemyのパラメータを管理する
public class BossStats : MonoBehaviour{

    private int _hp; // HP
    private int _maxHp; // 最大HPを設定
    private int _attack; // 攻撃力
    private float _speed; // スピード
    private string _qText, _aText, _mText; // 問題(漢字)、解答(ローマ字)、読み方(ひらがな)

    private EnemyGenerator _enemyGenerator; // EnemyGeneratorへの参照
    private ScoreManager _scoreManager; // ScoreManagerへの参照

    private bool _isAlive = true; // Enemyが生きていたらtrue、一度削除されたらfalse
    // 初期化メソッド
    public void Initialize(int hp, int attack, float speed, string qText, string aText, string mText){
        _hp = hp;       // HPを設定
        _maxHp = hp; // 最大HPを設定
        _attack = attack; // 攻撃力を設定
        _speed = speed; // スピードを設定
        _qText = qText; // 問題文を設定
        _aText = aText; // 解答を設定
        _mText = mText; // 読み方を設定
    }

    // Start is called before the first frame update
    void Start()
    {
        // EnemyGeneratorを取得
        _enemyGenerator = FindObjectOfType<EnemyGenerator>();
        // ScoreManagerを取得
        _scoreManager = FindObjectOfType<ScoreManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bossが生きている時、HPが0以下でゲームクリア
        if(_hp <= 0 && _isAlive){
            Debug.Log("Boss is Death");
            // 敵を倒した音
            AudioManager.Instance.PlaySound(AudioManager.Instance.defeatSound);
            _isAlive = false;
            _scoreManager.AddDefeatCount(); // 撃破数+1
            // ゲームクリア
            GameManager.Instance.BossIsDeath(); 
        }
        
    }

    // Enemyへのdamage
    public void DamageToEnemy(int damage){
        _hp -= damage;
    }

    // HPのゲッター
    public int GetHP(){
        return _hp;
    }
    // 最大HPのゲッター
    public int GetMaxHP(){
        return _maxHp;
    }
    // スピードのゲッター
    public float GetSpeed(){
        return _speed;
    }
    // 攻撃力のゲッター
    public int GetAttack(){
        return _attack;
    }
    // 問題、解答、読み方のゲッター関数
    public string GetQText(){
        return _qText;
    }
    public string GetAText(){
        return _aText;
    }
    public string GetMText(){
        return _mText;
    }

}
