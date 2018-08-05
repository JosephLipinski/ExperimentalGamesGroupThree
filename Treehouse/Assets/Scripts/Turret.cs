using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    float speed = 10f;
    float damageAmount = 1f;
    public GameObject teeBall, spawnPoint;
    Vector3 SpawnPoint;

    private void Start()
    {
        SpawnPoint = spawnPoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy"){
            //Debug.Log("Entered");
            other.gameObject.GetComponent<BasicEnemy>().StartFiring(this.gameObject.GetComponent<Turret>());
        }
    }

    public void Fire(GameObject other){
        GameObject spawned = Instantiate(teeBall);
        spawned.transform.position = SpawnPoint;
        spawned.GetComponent<TeeBall>().Setup(other.gameObject, speed, damageAmount);
    }
    /*
    void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Enemy"){
            GameObject spawned = Instantiate(teeBall);

            spawned.GetComponent<TeeBall>().Setup(other.gameObject, speed, damageAmount);
        }     
    }
    */

}
