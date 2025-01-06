using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float _collisionRange = 2.0f; // 衝突とみなす距離
    private float _chaseRange = 20.0f; // playerを追跡する距離
    private float distance; // playerとの距離

    private GameObject _player; // Player
    private PlayerStats _playerStats; // PlayerStatsへの参照

    private EnemyGenerator _enemyGenerator; // EnemyGeneratorへの参照
    private EnemyStats _enemyStats; // EnemyStatsへの参照

    private Vector3[] _initialDestination = new Vector3[2]; // 初期目的地2つ
    private int _currentTargetPositionIndex = 0; // どちらの初期目的地に向かうか

    private UnityEngine.AI.NavMeshAgent _agent; // NavMeshAgentを格納する変数

    // Start is called before the first frame update
    void Start()
    {
        // EnemyGeneratorを取得
        _enemyGenerator = FindObjectOfType<EnemyGenerator>();
        

        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgentコンポーネントを取得
        // 初期目的地を設定
        SetRandomInitialDestinations();
    }

    // Update is called once per frame
    void Update()
    {
        if(_player == null){
            _player = GameObject.FindWithTag("Player"); // タグで検索
            // PlayerStatsを取得
            _playerStats = _player.GetComponent<PlayerStats>(); 
        }
        if(_enemyStats == null){
            // EnemyStatsを取得
            _enemyStats = GetComponent<EnemyStats>();
            _agent.speed = _enemyStats.GetSpeed();
        }
        // playerとの距離を計算
        distance = Vector3.Distance(_player.transform.position, transform.position);

        // 距離が2.0以下で衝突とみなす
        if(distance < _collisionRange){
            OnPlayerCollision();
        }
        // 距離が20以下で追いかける
        else if (distance <= _chaseRange){
            // playerのいる位置へ動く
            MoveToNextPosition(_player.transform.position);
        }
        // 範囲外なら初期目的を往復
        else{
            // 初期目的地に着いたら目的地を入れ替える
            ChangeInitialDestination();
            // 目的地へ行く
            MoveToNextPosition(_initialDestination[_currentTargetPositionIndex]); 
        }
        
        
    }

    // 初期の目的地をランダムに設定
    void SetRandomInitialDestinations(){
        //_initialDestination[0] = GetRandomNavMeshPosition(); // ランダムな位置を取得
        //_initialDestination[1] = GetRandomNavMeshPosition(); // もう1つランダムな位置を取得
        _initialDestination[0] = transform.position;
        List<Vector3> position = new List<Vector3>();
        position = _enemyGenerator.GetOtherPositions();
        int index = Random.Range(0, position.Count);
        Vector3 p = position[index];
        _initialDestination[1] = p;
        _enemyGenerator.DeletePosition(p);
        //_initialDestination[1] = transform.position;
        //_initialDestination[1] = _enemyGenerator.GetRandomPosition();
    }


    // ランダムなNavMesh上の位置を取得
    Vector3 GetRandomNavMeshPosition(){
        // ランダムな位置を生成
        float x = Random.Range(-10.0f, 10.0f);
        float z = Random.Range(-10.0f, 10.0f);
        Vector3 randomPosition = new Vector3(x, 0f, z) + transform.position;

        // NavMesh上の位置を調べる
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomPosition, out hit, 5.0f, UnityEngine.AI.NavMesh.AllAreas)){ // 5.0fは範囲の大きさ
            return hit.position; // NavMesh上の有効な位置を返す
        }

        // 見つからなかった場合、再帰的に位置を再設定
        return GetRandomNavMeshPosition();
    }

    // 衝突時の処理
    private void OnPlayerCollision(){

        
        // Playerにダメージを与える
        _playerStats.DamageToPlayer(_enemyStats.GetAttack()); // 攻撃力分のダメージ
        // ダメージ音
        AudioManager.Instance.PlaySound(AudioManager.Instance.damageSound);

        // このEnemyを消去
        _enemyGenerator.RemoveEnemy(gameObject);

    }

    // 初期の目的地を変更する
    void ChangeInitialDestination(){
        // NavMeshAgentの残りの距離が停止距離より小さい場合に目的地到達とみなす
        if(_agent.remainingDistance <= _agent.stoppingDistance){
            // 他方の目的地に入れ替える
            if(_currentTargetPositionIndex == 0){
                _currentTargetPositionIndex = 1;
            }
            else{
                _currentTargetPositionIndex = 0;
            }
        }
    }


    // 目的地の方を向き、そこへ動く
    void MoveToNextPosition(Vector3 destination){
        Vector3 direction = destination - transform.position; // 目的地 - 現在地の方向ベクトル
        direction.y = transform.position.y; // y座標は固定
        transform.LookAt(direction); //x,z座標だけ目的地の方を見る
        _agent.SetDestination(destination);
    }

}
