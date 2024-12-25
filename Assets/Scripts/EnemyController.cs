using UnityEngine;
using UnityEngine.AI; // NavMeshAgentを使用するための名前空間

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent; // NavMeshAgentを格納する変数
    private Transform _playerTransform; // 追いかける対象のTransform
    private float _chaseRange = 20.0f; // 追いかける範囲
    private float _destroyRange = 2.0f; // 消える範囲

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); // NavMeshAgentコンポーネントを取得

        // playerオブジェクトをタグで検索し、Transformを取得
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Playerオブジェクトが見つかりません。Playerタグを確認してください。");
        }
    }

    void Update()
    {   
        // playerがなければ終わり
        if (_playerTransform == null){
            return;
        }

        // playerとの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);

        // 範囲内なら追いかける
        if (distanceToPlayer <= _chaseRange){
            _agent.SetDestination(_playerTransform.position); // 目的地をplayerに設定
        }

        // 一定の距離内に入ったらEnemyを消す
        if (distanceToPlayer <= _destroyRange){
            Destroy(gameObject); // Enemyオブジェクトを削除
            // ダメージ音
            AudioController.Instance.PlaySound(AudioController.Instance.damageSound);
            Debug.Log("Enemyが削除されました！");
        }
    }
}
