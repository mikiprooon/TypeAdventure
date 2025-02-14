using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainSceneManager : MonoBehaviour
{
    [SerializeField] private Button _returnButton; // あそびかたボタンの参照

    void Start()
    {
        
        // ボタンのクリックイベントにメソッドを登録
        if ( _returnButton != null){
             _returnButton.onClick.AddListener(OnReturnButtonClicked);
        }

    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnReturnButtonClicked()
    {
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadStartScene();
        }

    }
}
