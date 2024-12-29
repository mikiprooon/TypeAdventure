using UnityEngine;
using UnityEngine.AI; // NavMeshAgentを使用するための名前空間

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent; // NavMeshAgentを格納する変数
    private Transform _playerTransform; // 追いかける対象のTransform
    private float _chaseRange = 20.0f; // 追いかける範囲
    private float _destroyRange = 2.0f; // 消える範囲

    private Vector3[] _initialDestination = new Vector3[2]; // 初期目的地2つ
    private int _currentTargetPositionIndex = 0; // どちらの初期目的地に向かうか

    private float _distance; // playerとの距離

    private int _HP; // 体力
    private string[] _answer = {"mondai", "kaitou", "yomikata"};
    private string[] _question = {"問題", "解答", "読み方"};
    private string[] _meaning = {"もんだい", "かいとう", "よみかた"};
     // 答えを保存しておく
    private string _aText; // ローマ字
    private string _qText; // 問題文
    private string _mText; // 読み方

    private TextController _textController;


    void Start()
    {   
        CreateQuestion(); // 問題を設定
        _textController = FindObjectOfType<TextController>();
        _textController.SetQuestion(_aText, _qText, _mText);

        _agent = GetComponent<NavMeshAgent>(); // NavMeshAgentコンポーネントを取得
        _initialDestination[0] = new Vector3(-0.37f, -0.007f, 9.6f);
        _initialDestination[1] = new Vector3(5.0f, -0.007f, 9.6f);

        // playerオブジェクトをタグで検索し、Transformを取得
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null){
            _playerTransform = player.transform;
        }
        else{
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
            // playerのいる位置へ動く
            MoveToNextPosition(_playerTransform.position);
        }
        // 範囲外なら初期目的を往復
        else{
            // 初期目的地に着いたら目的地を入れ替える
            ChangeInitialDestination();
            // 目的地へ行く
            MoveToNextPosition(_initialDestination[_currentTargetPositionIndex]); 
        }
        Debug.Log(transform.forward);

    }

    // 初期の目的地を変更する
    void ChangeInitialDestination(){
        // 一方の初期目的地に着いたなら
        if(Vector3.Distance(transform.position, _initialDestination[_currentTargetPositionIndex]) <= 0.1f){
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

    // playerとの距離を設定
    void SetDistance(float distance){
        _distance = distance;
    }

    // HPの設定
    void SetHP(int hp){
        _HP = hp;
    }

    // 問題を作成・表示
    private void CreateQuestion(){
        //問題番号を決める
        int _qNum = Random.Range(0, _question.Length); 

        //答え用の変数に保存
        _aText = _answer[_qNum];
        _qText = _question[_qNum]; 
        _mText = _meaning[_qNum]; 
 
    }
}
