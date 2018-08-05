using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject basicEnemy, bigEnemy;
    public GameObject spawnPoint;

    void Start(){
        SpawnEnemies(basicEnemy);
    }



    void SpawnEnemies(GameObject enemy){
        GameObject spawned = Instantiate(enemy) as GameObject;
        spawned.transform.position = spawnPoint.transform.position;
        spawned = null;
    }
}
