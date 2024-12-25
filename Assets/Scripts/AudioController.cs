using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{   
    // AudioControllerクラスのどこからでもInstanceにアクセスできる
    public static AudioController Instance; 

    // 効果音の設定
    public AudioClip missSound; // ミスした時
    public AudioClip attackSound; // 正しい文字を打ち込んだ時
    public AudioClip defeatSound; // 敵を倒した時
    public AudioClip damageSound; // 攻撃された時
    private AudioSource _audioSource; 

    // シーンの読み込み時に一度だけ実行
    void Awake(){ 
        // シングルトンパターン
        if (Instance == null)
        {
            Instance = this; // このオブジェクトをインスタンスとして設定
            DontDestroyOnLoad(gameObject); // シーンを跨いでも存在させる
        }
        else
        {
            Destroy(gameObject); // 重複したインスタンスを破棄
        }
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>(); // コンポーネントを取得
    }

    // 音を再生
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && _audioSource != null){
            _audioSource.PlayOneShot(clip);
        }
    }
}
