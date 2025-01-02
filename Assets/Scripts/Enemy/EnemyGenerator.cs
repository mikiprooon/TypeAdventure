using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyをPrefabから自動生成する
public class EnemyGenerator : MonoBehaviour{
    [SerializeField] GameObject _enemyPrefab; // 敵キャラクタのPrefab
    private int _initialEnemyCount = 3; // 初期生成数
    private float _spawnAreaSize = 20.0f; // 敵の生成範囲
    [SerializeField] private GameObject _player;
    private PlayerController _playerController;

    private List<GameObject> _enemies = new List<GameObject>(); // 全Enemyを保持するリスト
    private WordDatabase _wordDatabase; // 問題文を管理するデータベース

    private void Start()
    {   
        // PlayerControllerを取得
        _playerController = _player.GetComponent<PlayerController>();

        // WordDatabaseを取得
        _wordDatabase = FindObjectOfType<WordDatabase>();
        if (_wordDatabase == null){
            Debug.LogError("WordDatabaseが見つかりません。正しく配置されているか確認してください。");
            return;
        }

        // 初期生成
        for (int i = 0; i <_initialEnemyCount; i++){
            SpawnEnemy(GetRandomPosition());
            
        }
    }

    // ランダムな位置を取得する
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-_spawnAreaSize, _spawnAreaSize);
        float z = Random.Range(-_spawnAreaSize, _spawnAreaSize);
        return new Vector3(x, 0.007f, z);
    }

    // PrefabからEnemyを生成する
    private void SpawnEnemy(Vector3 position){
        // Prefabから新しいEnemyを生成
        GameObject newEnemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        _enemies.Add(newEnemy); // リストに追加

        // EnemyStatsを初期化
        EnemyStats stats = newEnemy.GetComponent<EnemyStats>();
        if (stats != null){
            // ランダムに問題文を取得
            (string qText, string aText, string mText) = _wordDatabase.GetNormalRandomWord();

            // HP = 1、speed = 3.0で初期化
            int hp = aText.Length; // HPは文字数
            int attack = 1; // 攻撃力は1
            float speed = 3.0f;         // 初期スピードは固定
            stats.Initialize(hp, attack, speed, qText, aText, mText); // 初期化

            // 表示するテキストの設定
            TextController textController = newEnemy.GetComponentInChildren<TextController>(); // TextControllerを子オブジェクトから取得
            textController.SetText(); // TextControllerのSetText()を呼び出して、表示内容を更新
            Debug.Log($"Enemy生成: HP={hp}, Speed={speed}, 問題={qText}, 解答={aText}, 読み方={mText}");
        }
        else
        {
            Debug.LogError("EnemyStatsがEnemyPrefabにアタッチされていません！");
        }
    }

    // Enemyを削除する
    public void RemoveEnemy(GameObject enemy){
        if (_enemies.Contains(enemy)){
            _enemies.Remove(enemy);
            Destroy(enemy);
            Debug.Log($"Enemyを削除しました。現在のEnemy数: {_enemies.Count}");
        }
        else{
            Debug.LogWarning("削除しようとしたEnemyがリストに存在しません。");
        }
    }

    // 全Enemyを取得
    public List<GameObject> GetAllEnemies(){
        return new List<GameObject>(_enemies); // コピーを返すことで外部からの直接変更を防ぐ
    }

}
