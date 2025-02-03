using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 【UnityC#】カメラが壁を貫通しないようにする方法
// はてなブログ EDunityさん
// https://edunity.hatenablog.com/entry/20201029/1603946279
// 参照日: 2025/01/05

public class PlayerCameraController : MonoBehaviour
{
    private GameObject _player; //  Playerオブジェクト
    private PlayerController _playerController; //PlayerControllerへの参照

    [SerializeField] private GameObject _mainCamera; // 移動用メインカメラ
    [SerializeField] private GameObject _subCamera; // タイピング用サブカメラ

    private Vector3 _position; // Cameraの初期の相対位置

    private RaycastHit _hit; // レイを飛ばす

    private float _distance; // Playerとの距離

    private int _mask; // Playerを無視するために必要

    void Start()
    {
        // Playerの位置を取得
        _player = gameObject;
        _playerController = _player.GetComponent<PlayerController>();

        // 親との相対位置を取得
        _position = _mainCamera.transform.localPosition;

        // CameraとPlayerの距離を取得
        _distance = Vector3.Distance(_player.transform.position, _mainCamera.transform.position);

        // PlayerレイヤーのオブジェクトをRayCastで無視する
        _mask = ~(1 << LayerMask.NameToLayer("Player"));

        // SubCameraを非アクティブにする
        _subCamera.SetActive(false);
    }

    void Update()
    {
        // Playerを中心とした0.3の球の中に障害物がある時
        if(Physics.CheckSphere(_player.transform.position, 0.3f, _mask)){
            // Cameraの位置をLerpでPlayerの位置に変化させる
            _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _player.transform.position, 1);
        }
        // PlayerとCameraの間に障害物がある時
        // PlayerからCameraにRayを飛ばし、障害物にヒットしたらその場所を_hitに保存する
        else if (Physics.SphereCast(_player.transform.position, 0.3f, (_mainCamera.transform.position - _player.transform.position).normalized, out _hit, _distance, _mask)){
            // Cameraの位置をぶつかった地点に移動させる
            _mainCamera.transform.position = _player.transform.position + (_mainCamera.transform.position - _player.transform.position).normalized * _hit.distance;
        }
        // 障害物がない時
        else{
            // Cameraを元のローカル位置に戻す
            _mainCamera.transform.localPosition = Vector3.Lerp(_mainCamera.transform.localPosition, _position, 1);
        }

        // Playerが移動モードかタイピングモードかで位置を変える
        // タイピングモードの時
        if(_playerController.GetIsTypeMode()){ 
            _mainCamera.SetActive(false);
            _subCamera.SetActive(true);
            //_subCamera.transform.position = new Vector3(transform.position.x, _playerController.GetTargetTextPosition().y - 1.5f, transform.position.z);
        }
        // 移動モードの時
        else{ 
            _mainCamera.SetActive(true);
            _subCamera.SetActive(false);

        }
    }
}