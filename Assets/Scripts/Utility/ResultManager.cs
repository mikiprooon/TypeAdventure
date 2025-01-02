using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    private GameObject _sm; // ScoreManagerオブジェクト
    private ScoreManager _scoreManager; // ScoreManagerへの参照

    // 4種のTMPを取得
    [SerializeField] private TextMeshProUGUI _typesPerSecondTMP; // 正解タイプ回数/秒
    [SerializeField] private TextMeshProUGUI _missTypeTMP; // ミス数
    [SerializeField] private TextMeshProUGUI _defeatTMP; // 撃破数
    [SerializeField] private TextMeshProUGUI _totalScoreTMP; // 総合スコア

    // 4種のスコア
    private float _typesPerSeconds; // 正解タイプ回数/秒
    private int _missType; // ミス数
    private int _defeat; // 撃破数
    private float _totalScore; // 総合スコア

    private float _time = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_scoreManager == null){
            // ScoreManagerを取得
            _scoreManager = FindObjectOfType<ScoreManager>();

            _typesPerSeconds = _scoreManager.GetTypesPerSecond();
            _missType = _scoreManager.GetMissTypeCount();
            _defeat = _scoreManager.GetDefeatCount();
            _totalScore = _scoreManager.GetTotalScore();
            Destroy(GameObject.FindWithTag("Player")); // リザルト画面ではplayerは削除
        }

        if(_time < 1.0f){
            _typesPerSecondTMP.text = Random.Range(1, 100) + " 回 / 秒";
            _missTypeTMP.text = Random.Range(1, 100) + " 回";
            _defeatTMP.text = Random.Range(1, 100) + " 体";
            _totalScoreTMP.text = Random.Range(1, 100) + " 点";

            _time += Time.deltaTime;
        }
        else{
            _typesPerSecondTMP.text = _typesPerSeconds.ToString("F2") + " 回 / 秒";
            _missTypeTMP.text = _missType + " 回";
            _defeatTMP.text = _defeat + " 体";
            _totalScoreTMP.text = _totalScore.ToString("F2") + " 点";
        }
        
        
    }
}
