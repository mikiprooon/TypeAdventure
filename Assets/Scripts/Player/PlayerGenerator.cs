using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Playerを生成する
public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab; // プレイヤキャラクタのPrefab
    
    
    void Start()
    {
        // Player をPrefabから生成
        GameObject player = Instantiate(_playerPrefab, new Vector3(0f, 1.47f, 0f), Quaternion.identity);
        
        // EnemyStatsを初期化
        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (stats != null){
            // HP = 15、attac = 1, speed = 8.0で初期化
            stats.Initialize(15, 1, 8f); // 初期化
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
