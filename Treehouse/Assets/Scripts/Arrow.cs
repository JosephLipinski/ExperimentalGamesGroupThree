using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    Rigidbody _rb;
    public float thrust;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseThrust(){
        thrust += 10 * Time.deltaTime;
    }

    public void Fire()
    {
        _rb.isKinematic = false;
        Vector3 direction = transform.forward;
        direction.z = direction.z * thrust;
        _rb.AddForce(direction, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<BasicEnemy>().TakeDamage(thrust);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
    }
}
