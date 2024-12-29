using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵キャラのprefab
    private List<GameObject> _enemies = new List<GameObject>(); // 全Enemyを保持するリスト

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < 1; i++){
            SpawnEnemy(new Vector3(Random.Range(-20.0f, 20.0f), 0.007f, Random.Range(-20.0f, 20.0f)));     
        }
        
    }

    // PrefabからEnemyを生成
    public void SpawnEnemy(Vector3 position){
        GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        _enemies.Add(newEnemy); // Listに追加
        Debug.Log(newEnemy);
    }

    // Enemyをリストから削除して破棄
    public void RemoveEnemy(GameObject enemy){
        if (_enemies.Contains(enemy)){
            _enemies.Remove(enemy);
            Destroy(enemy);
            Debug.Log($"Enemyを削除しました。現在のEnemy数: {_enemies.Count}");
        }
        else {
            Debug.LogWarning("削除しようとしたEnemyがリストに存在しません。");
        }
    }

    // 全Enemyを取得
    public List<GameObject> GetAllEnemies(){
        return new List<GameObject>(_enemies); // コピーを返すことで外部からの直接変更を防ぐ
    }


}
