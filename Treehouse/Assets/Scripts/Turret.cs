using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float damageAmount = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy"){
            GameObject enemy = other.gameObject;
            enemy.GetComponent<BasicEnemy>().TakeDamage(damageAmount);
        }
    }

    void OnTriggerStay(Collider other){
        if (other.gameObject.tag == "Enemy"){
            GameObject enemy = other.gameObject;
            enemy.GetComponent<BasicEnemy>().TakeDamage(damageAmount);
        }     
    }

}
