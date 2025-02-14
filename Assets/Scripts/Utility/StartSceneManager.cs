using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private Button _easyButton; // かんたんボタンの参照
    [SerializeField] private Button _normalButton; // ふつうボタンの参照
    [SerializeField] private Button _hardButton; // むずかしいボタンの参照
    [SerializeField] private Button _veryhardButton; // 超むずかしいボタンの参照
    [SerializeField] private Button _specialButton; // スペシャルボタンの参照
    [SerializeField] private Button _explainButton; // あそびかたボタンの参照

    void Start()
    {
        // ボタンのクリックイベントにメソッドを登録
        if ( _easyButton != null){
             _easyButton.onClick.AddListener(OnEasyButtonClicked);
        }
        // ボタンのクリックイベントにメソッドを登録
        if ( _normalButton != null){
             _normalButton.onClick.AddListener(OnNormalButtonClicked);
        }
        // ボタンのクリックイベントにメソッドを登録
        if ( _hardButton != null){
             _hardButton.onClick.AddListener(OnHardButtonClicked);
        }
        // ボタンのクリックイベントにメソッドを登録
        if ( _veryhardButton != null){
             _veryhardButton.onClick.AddListener(OnVeryhardButtonClicked);
        }
        // ボタンのクリックイベントにメソッドを登録
        if ( _specialButton != null){
             _specialButton.onClick.AddListener(OnSpecialButtonClicked);
        }
        // ボタンのクリックイベントにメソッドを登録
        if ( _explainButton != null){
             _explainButton.onClick.AddListener(OnExplainButtonClicked);
        }

    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnEasyButtonClicked()
    {
        GameManager.Instance.SetLevel(1);
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadSampleScene();
        }

    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnNormalButtonClicked()
    {
        GameManager.Instance.SetLevel(2);
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadSampleScene();
        }

    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnHardButtonClicked()
    {
        GameManager.Instance.SetLevel(3);
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadSampleScene();
        }

    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnVeryhardButtonClicked()
    {
        GameManager.Instance.SetLevel(4);
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadSampleScene();
        }

    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnSpecialButtonClicked()
    {
        GameManager.Instance.SetLevel(5);
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadSampleScene();
        }

    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnExplainButtonClicked()
    {
        // GameManagerのインスタンスを介してシーンをロード
        if (GameManager.Instance != null){
            GameManager.Instance.LoadExplainScene();
        }

    }
}
