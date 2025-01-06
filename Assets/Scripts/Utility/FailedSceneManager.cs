using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailedSceneManager : MonoBehaviour
{
    [SerializeField] private Button _replayButton; // ボタンの参照

    void Start()
    {
        // ボタンのクリックイベントにメソッドを登録
        if ( _replayButton != null){
            _replayButton.onClick.AddListener(OnReplayButtonClicked);
        }
  
    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnReplayButtonClicked(){
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadStartScene();
        }

    }
}
