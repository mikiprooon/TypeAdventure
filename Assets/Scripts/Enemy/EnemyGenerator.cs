using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyをPrefabから自動生成する
public class EnemyGenerator : MonoBehaviour{
    [SerializeField] GameObject _enemyPrefab; // 敵キャラクタのPrefab
    private int _initialEnemyCount = 20; // 初期生成数
    private float _spawnAreaSize = 20.0f; // 敵の生成範囲

    // Player関連の参照
    [SerializeField] private GameObject _player;
    private PlayerController _playerController;

    private List<GameObject> _enemies = new List<GameObject>(); // 全Enemyを保持するリスト
    private WordDatabase _wordDatabase; // 問題文を管理するデータベース

    private List<Vector3> _enemySpawnPositionList = new List<Vector3>();
    private GameObject[] _enemySpawnPositionArray;

    [SerializeField] GameObject _bossPrefab; // ボスキャラクタのPrefab
    private GameObject _boss; // ボスのゲームオブジェクト
    private Vector3 _bossSpawnPosition; // ボスの出現場所
    private GameObject _bossFloor; // ボスのいる部屋

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

        // Floorタグのオブジェクトを全て取得
        _enemySpawnPositionArray = GameObject.FindGameObjectsWithTag("Floor");
        // ListにFloorの位置を保存
        foreach(GameObject floor in _enemySpawnPositionArray){
            _enemySpawnPositionList.Add(floor.transform.position + new Vector3(0f, 0.14f, 0f));
        }

        // BossFloorオブジェクトを取得
        _bossFloor = GameObject.FindWithTag("BossFloor");
        // ボスのスポーン位置を取得
        _bossSpawnPosition = _bossFloor.transform.position; 
        

        // Enemy初期生成
        for (int i = 0; i <_initialEnemyCount; i++){
            SpawnEnemy(GetRandomPosition());
        }
        // Boss初期生成
        SpawnBoss(_bossSpawnPosition);
    }


    // ランダムな位置を取得する
    public Vector3 GetRandomPosition()
    {
        // スポーン場所を決める
        int index = Random.Range(0, _enemySpawnPositionList.Count);
        // スポーン場所が被らないように選ばれた場所は削除
        Vector3 position = _enemySpawnPositionList[index];
        _enemySpawnPositionList.Remove(_enemySpawnPositionList[index]);
        
        return position;
    }

    public List<Vector3> GetOtherPositions(){
        return _enemySpawnPositionList;
    }

    public void DeletePosition(Vector3 position){
        _enemySpawnPositionList.Remove(position);
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
            (string qText, string aText, string mText) = _wordDatabase.GetRandomWord(GameManager.Instance.GetLevel());

            // HP = 1、speed = 3.0で初期化
            int hp = aText.Length; // HPは文字数
            int attack = 1; // 攻撃力は1
            float speed = 1.5f;         // 初期スピードは固定
            stats.Initialize(hp, attack, speed, qText, aText, mText); // 初期化

            // 表示するテキストの設定
            TextController textController = newEnemy.GetComponentInChildren<TextController>(); // TextControllerを子オブジェクトから取得
            textController.SetText(); // TextControllerのSetText()を呼び出して、表示内容を更新
        }
     
    }

    private void SpawnBoss(Vector3 position){
        // Prefabから新しいEnemyを生成
        _boss = Instantiate(_bossPrefab, position, Quaternion.identity);

        // EnemyStatsを初期化
        BossStats bossStats = _boss.GetComponent<BossStats>();
        if (bossStats != null){
            // ランダムに問題文を取得
            (string qText, string aText, string mText) = _wordDatabase.GetBossRandomWord(GameManager.Instance.GetLevel());

            Debug.Log("Boss text: " + aText);
            // HP = 文字数、speed = 10.0で初期化
            int hp = aText.Length; // HPは文字数
            int attack = 3; // 攻撃力は3
            float speed = 3.0f;         // 初期スピードは固定
            bossStats.Initialize(hp, attack, speed, qText, aText, mText); // 初期化

            // 表示するテキストの設定
            TextController textController = _boss.GetComponentInChildren<TextController>(); // TextControllerを子オブジェクトから取得
            textController.SetText(); // TextControllerのSetText()を呼び出して、表示内容を更新
            
        }


    }

    // Enemyを削除する
    public void RemoveEnemy(GameObject enemy){
        if (_enemies.Contains(enemy)){
            _enemies.Remove(enemy);
            Destroy(enemy);
        }

    }

    // 全Enemyを取得
    public List<GameObject> GetAllEnemies(){
        return new List<GameObject>(_enemies); // コピーを返すことで外部からの直接変更を防ぐ
    }

}
