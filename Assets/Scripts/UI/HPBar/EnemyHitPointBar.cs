using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHitPointBarController : MonoBehaviour
{
    private Slider _hpSlider; // HPバーのSlider
    private EnemyStats _enemyStats; // EnemyStatsへの参照

    void Start()
    {
        // Sliderを取得
        _hpSlider = GetComponent<Slider>();
        
    }

    void Update()
    {
        // _enemyStasが取得されてなければ
        if(_enemyStats == null){
            // EnemyStatsを取得
            _enemyStats = GetComponentInParent<EnemyStats>();

            if (_hpSlider == null){
                Debug.LogError("HP Sliderが割り当てられていません！");
            }

            // 初期設定
            _hpSlider.maxValue = _enemyStats.GetMaxHP();
            _hpSlider.value = _enemyStats.GetHP();
        }
        // 取得されていれば
        else{
            // 現在のHPを反映
            _hpSlider.value = _enemyStats.GetHP();
        }
        
    }
}
