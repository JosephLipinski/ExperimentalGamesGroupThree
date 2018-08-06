using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecrementer : MonoBehaviour {

    public HealthUI _hUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy"){
            //_hUI.TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
}
