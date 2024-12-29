using UnityEngine;
using System.Collections.Generic;

public class CollisionEventController : MonoBehaviour
{
    private GameObject _player; // PlayerのTransform
    private List<GameObject> _enemies = new List<GameObject>(); // Enemyのリスト
    private EnemyGenerator _enemyGenerator; // EnemyGeneratorの参照

    private float _collisionRange = 2.0f; // 衝突を判定する距離
    private float _battleRange = 20.0f; // playerがターゲットとする、enemyがplayerを追跡する距離

    void Start()
    {
        // Playerオブジェクトをタグで検索し取得
        _player = GameObject.FindGameObjectWithTag("Player");

        // EnemyGeneratorを取得
        _enemyGenerator = FindObjectOfType<EnemyGenerator>();

    }

    void Update()
    {
        // Enemyのリストを更新
        _enemies = _enemyGenerator.GetAllEnemies();

        // 各Enemyとの距離を計算し、衝突を判定
        foreach (GameObject enemy in _enemies){
            if (enemy == null){
                continue; // NullになったEnemyを無視
            }

            // playerと各enemyの距離
            float distance = Vector3.Distance(_player.transform.position, enemy.transform.position);
            // 衝突した時
            if (distance < _collisionRange){ 
                CollisionPlayerEnemy(enemy); // 衝突処理
            }
            else if(distance < _battleRange){

            }
        }
    }

    // 衝突時の処理
    private void CollisionPlayerEnemy(GameObject enemy){
        Debug.Log($"Playerと{enemy.name}が衝突しました！");
        
        // 例: Enemyを削除
        _enemyGenerator.RemoveEnemy(enemy);

        // ダメージ音
        AudioController.Instance.PlaySound(AudioController.Instance.damageSound);
    }
}
