using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public float rotationAmount;

    public void SpawnEnemies(GameObject enemy){
        GameObject spawned = Instantiate(enemy) as GameObject;
        spawned.transform.position = spawnPoint.transform.position;
        spawned.transform.Rotate(Vector3.up, rotationAmount);
        spawned = null;

    }


}
