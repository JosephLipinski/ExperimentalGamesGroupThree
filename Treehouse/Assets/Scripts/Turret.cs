using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float multiplier = 1f;
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
    public void CallFire(GameObject other){
        StartCoroutine(Fire(other));
    }
    public IEnumerator Fire(GameObject other){
        for (int i = 1; i <= multiplier; i++){
            GameObject spawned = Instantiate(teeBall);
            spawned.transform.position = SpawnPoint;
            spawned.GetComponent<TeeBall>().Setup(other.gameObject, speed, damageAmount);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Upgrade(){
        damageAmount++;
        multiplier = Mathf.Pow(2f, (damageAmount - 1f));
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
