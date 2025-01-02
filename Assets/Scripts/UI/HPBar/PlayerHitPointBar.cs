using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitPointBarController : MonoBehaviour
{
    private Slider _hpSlider; // HPバーのSlider
    private PlayerStats _playerStats; // PlayerStatsへの参照

    void Start()
    {
        _hpSlider = GetComponent<Slider>(); // Sliderを取得
        
    }

    void Update()
    {
        if(_playerStats == null){
            // PlayerStatsを取得
            _playerStats = GetComponentInParent<PlayerStats>();

            if (_hpSlider == null){
                Debug.LogError("HP Sliderが割り当てられていません！");
            }

            // 初期設定
            _hpSlider.maxValue = _playerStats.GetMaxHP();
            _hpSlider.value = _playerStats.GetHP();
        }
        else{
            // 現在のHPを反映
            _hpSlider.value = _playerStats.GetHP();
        }

    }
}

