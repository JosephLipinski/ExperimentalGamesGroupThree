using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    
    public GameObject treehouse;
    public float moveSpeed;
    public float health;
    public int resourcesRefund;
    Turret turret;

    // Use this for initialization
    void Start()
    {
        moveSpeed = Random.Range(2f, 6f);
        treehouse = GameObject.Find("Treehouse/Tree Trunk");
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, treehouse.transform.position, step);
    }

    public void StartFiring(Turret _turret){
        turret = _turret;
        turret.CallFire(gameObject);
        StartCoroutine(KeepFiring());
    }

    IEnumerator KeepFiring(){
        while (true){
            
            yield return new WaitForSeconds(1.0f);
            turret.CallFire(this.gameObject);
        }
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            ResourceManager.instance.GainResources(resourcesRefund);
            Destroy(this.gameObject);
        }
    }
}

