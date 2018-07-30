using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour {

    NavMeshAgent agent;
    public GameObject treehouse;
    public float health;


	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        treehouse = GameObject.Find("Treehouse/Tree Trunk");
        agent.SetDestination(treehouse.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float damageAmount){
        health -= damageAmount;
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
}
