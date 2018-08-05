using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeeBall : MonoBehaviour {

    GameObject target;
    float travelSpeed, damageAmount;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (target != null){
            float step = travelSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else{
            _rb.useGravity = true;
        }
	}

    public void Setup(GameObject _target, float speed, float damage)
    {
        target = _target;
        travelSpeed = speed;
        damageAmount = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<BasicEnemy>().TakeDamage(damageAmount);
            Destroy(this.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }


}
