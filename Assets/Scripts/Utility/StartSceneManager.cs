using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private Button _normalButton; // ボタンの参照

    void Start()
    {
        // ボタンのクリックイベントにメソッドを登録
        if ( _normalButton != null){
             _normalButton.onClick.AddListener(OnNormalButtonClicked);
        }
    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnNormalButtonClicked()
    {
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadSampleScene();
        }

    }
}
