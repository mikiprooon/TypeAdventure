using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanvasController : MonoBehaviour
{
    private Transform _mainCameraTransform; // Main Camera の Transform

    void Start()
    {
        // Main Camera を取得
        if (Camera.main != null){
            _mainCameraTransform = Camera.main.transform;
        }
        else{
            Debug.LogError("Main Camera がシーンに見つかりません");
        }
        // カメラに向けると反転するので、あらかじめ180度回す
        transform.localScale = new Vector3 (-1, 1, 1);
    }

    void Update()
    {
        // カメラの方に向け
        transform.LookAt(_mainCameraTransform);

    }
}

