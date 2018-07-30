using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GameObject spawned = Instantiate(enemy) as GameObject;
            spawned.transform.position = new Vector3(this.transform.position.x + 2f, transform.position.y, transform.position.z);
            spawned = null;

            yield return new WaitForSeconds(3.0f);
        }
        yield return null;
    }
}
