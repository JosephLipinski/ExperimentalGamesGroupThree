using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProperSpawner : MonoBehaviour {

    public List<GameObject> spawners = new List<GameObject>();
    public GameObject basicEnemy, bigEnemy, bossEnemy;
    public int time;
    public int difficulty = 0;
    public int random;



    // Use this for initialization
    void Start()
    {
        foreach (Transform child in transform)
        {
            spawners.Add(child.gameObject);
        }
        StartCoroutine(Track());
    }

    IEnumerator Track(){
        while(true){
            if(time % 10 == 0){
                difficulty += 1;
                SpawnUnits();
            }
            time += 5;

            yield return new WaitForSeconds(5.0f);
        }
    }

    void SpawnUnits(){
        if(difficulty < 4){
            for (int i = 0; i < difficulty; i++){
                spawners[i].GetComponent<EnemySpawner>().SpawnEnemies(basicEnemy);
            }
        }
        else if (difficulty < 8){
            for (int i = 0; i < 4; i++)
            {
                int random = Random.Range(0, 1);
                GameObject enemy = random == 0 ? basicEnemy : bigEnemy;
                spawners[i].GetComponent<EnemySpawner>().SpawnEnemies(enemy);
            }
        }
        else if (difficulty < 12)
        {
           
            for (int i = 0; i < 4; i++)
            {
                random = Random.Range(0, 2);
                GameObject enemy = random == 0 ? basicEnemy : bigEnemy;
                spawners[i].GetComponent<EnemySpawner>().SpawnEnemies(enemy);
            }

        }
        else{
            for (int i = 0; i < 4; i++)
            {
                random = Random.Range(0, 2);
                GameObject enemy = random == 0 ? bigEnemy : bossEnemy;
                spawners[i].GetComponent<EnemySpawner>().SpawnEnemies(enemy);
            }
        }
    }


}
