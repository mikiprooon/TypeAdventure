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

    private List<Vector3> _spawnPositionList = new List<Vector3>();
    private GameObject[] _spawnPositionArray;

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
        _spawnPositionArray = GameObject.FindGameObjectsWithTag("Floor");
        // ListにFloorの位置を保存
        foreach(GameObject floor in _spawnPositionArray){
            _spawnPositionList.Add(floor.transform.position + new Vector3(0f, 0.14f, 0f));
        }

        

        // 初期生成
        for (int i = 0; i <_initialEnemyCount; i++){
            SpawnEnemy(GetRandomPosition());
        }
    }

    // void Update(){
    //     Debug.Log("削除後Count: " + _spawnPositionList.Count);
    // }

    // ランダムな位置を取得する
    public Vector3 GetRandomPosition()
    {
        Debug.Log("削除前Count: " + _spawnPositionList.Count);
        // スポーン場所を決める
        int index = Random.Range(0, _spawnPositionList.Count);
        // スポーン場所が被らないように選ばれた場所は削除
        Vector3 position = _spawnPositionList[index];
        _spawnPositionList.Remove(_spawnPositionList[index]);

        Debug.Log("index: " + index);
        Debug.Log("削除後Count: " + _spawnPositionList.Count);
        
        return position;
    }

    public List<Vector3> GetOtherPositions(){
        return _spawnPositionList;
    }

    public void DeletePosition(Vector3 position){
        _spawnPositionList.Remove(position);
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
            float speed = 30.0f;         // 初期スピードは固定
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
