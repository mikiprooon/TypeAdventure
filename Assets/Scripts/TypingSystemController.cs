using UnityEngine;

public class TypingSystemController : MonoBehaviour
{
    private int _currentCharIndex = 0; // 何文字目を入力しているか
    private string _answer; // 正しい文字列

    private TextController _targetEnemyTextController; // enemyのTextControllerへの参照
    private GameObject _targetEnemy; // 現在のターゲットEnemy

    // タイピング開始時に呼び出すメソッド
    public void StartTyping(GameObject targetEnemy)
    {
        _targetEnemy = targetEnemy;
        _targetEnemyTextController = _targetEnemy.transform.Find("Canvas/Image").GetComponent<TextController>();
        _answer = _targetEnemyTextController.GetAnswerText();
    }

    // タイピングの処理
    public void HandleTyping()
    {
        Debug.Log("ここだよ");
        // ctrlキーが押されている場合、タイピング処理をスキップ
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            return;
        }

        // 入力されたキーが答えと一致しているなら
        if (Input.GetKeyDown(_answer[_currentCharIndex].ToString()))
        {
            InputCorrecKey(); // 正しい時の処理
        }
        // 間違えた入力なら
        else if (Input.anyKeyDown)
        {
            InputWrongKey(); // 誤った時の処理
        }
    }

    // 正しいキーの時の処理
    private void InputCorrecKey()
    {
        Debug.Log("正解");

        // 最後の文字を打ち終えたら
        if (_currentCharIndex + 1 >= _answer.Length)
        {
            Destroy(_targetEnemy); // 敵を消す
            // 敵を倒した音
            AudioController.Instance.PlaySound(AudioController.Instance.defeatSound);
            _currentCharIndex = 0; // インデックスを初期化
        }
        // 最後の文字でなければ
        else
        {
            // 攻撃音
            AudioController.Instance.PlaySound(AudioController.Instance.attackSound);
            _currentCharIndex++; // インデックスを+1
            // 正解した文字を灰色にする
            _targetEnemyTextController.ChangeTextColorCorrect(_currentCharIndex);
        }
    }

    // 間違ったキーの時の処理
    private void InputWrongKey()
    {
        Debug.Log("不正解");
        // ミス音
        AudioController.Instance.PlaySound(AudioController.Instance.missSound);
        // 間違えた字を赤くする
        _targetEnemyTextController.ChangeTextColorWrong(_currentCharIndex);
    }
}
