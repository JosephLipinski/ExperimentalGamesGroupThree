using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float thrust;
    Rigidbody _rb;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(KillArrow());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseThrust()
    {
        if(Mathf.Floor(thrust) < 75){
            thrust += 10 * Time.deltaTime;
        }
    }

    public void FireArrow(){
        _rb.isKinematic = false;
        Vector3 direction = transform.forward;
        direction.z = direction.z * thrust;
        _rb.AddForce(direction, ForceMode.Impulse);
        Debug.Log(direction);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<BasicEnemy>().TakeDamage(thrust);
            Destroy(this.gameObject);
        }

        else if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator KillArrow()
    {
        yield return new WaitForSeconds(8.0f);
        Destroy(gameObject);
    }
}
