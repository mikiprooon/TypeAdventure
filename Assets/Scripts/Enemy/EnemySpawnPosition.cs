using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPosition : MonoBehaviour
{

    // private List<Vector3> _scene1SpawnPositions = new List<Vector3>{
    //     new Vector3(0f, 2f, 10f),
    //     new Vector3(-10f, 2f, 0f)
    // };

    // private List<Vector3> _spawnPositionList;
    // private GameObject[] _spawnPositionArray;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     _spawnPositionArray = GameObject.FindGameObjectsWithTag("Floor");
    //     foreach(GameObject floor in _spawnPositionArray){
    //         _spawnPositionList.Add(floor.transform.position);
    //     }

        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // // シーン1でのスポーン場所をランダムに返す
    // public Vector3 GetScene1SpawnPositions(){
    //     // スポーン場所を決める
    //     int index = Random.Range(0, _scene1SpawnPositions.Count);
    //     // スポーン場所が被らないように選ばれた場所は削除
    //     Vector3 position = _scene1SpawnPositions[index];
    //     _scene1SpawnPositions.Remove(_scene1SpawnPositions[index]);

    //     return position;
    // }
}
