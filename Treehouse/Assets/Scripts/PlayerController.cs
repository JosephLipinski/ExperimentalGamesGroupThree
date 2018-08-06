using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera _camera;
    public float moveSpeed;
    public GameObject turret, arrow;
    Arrow _arrow;
    GameObject arrowToFire;
    Vector3 originalPosition;
    Rigidbody _rb;


	// Use this for initialization
	void Start () {
        moveSpeed = 5f;

        originalPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.W)){
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0, Space.Self);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Time.deltaTime * moveSpeed, 0, 0, Space.Self);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            _rb.AddForce(new Vector3(0f, 5f, 0f), ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.Return)){
            if (arrowToFire == null)
            {
                arrowToFire = Instantiate(arrow);
                arrowToFire.transform.position = GameObject.Find("Player/Arrow Position").transform.position;
                arrowToFire.transform.parent = GameObject.Find("Player/Arrow Position").transform;
                _arrow = arrowToFire.GetComponent<Arrow>();
            }
            else{
                _arrow.IncreaseThrust();
            }
        }
        if(Input.GetKeyUp(KeyCode.Return)){
            if(arrowToFire != null){
                arrowToFire.transform.parent = null;
                arrowToFire.GetComponent<Arrow>().Fire();
                StartCoroutine(KillArrow());
            }
        }
	}

    IEnumerator KillArrow(){
        yield return new WaitForSeconds(5.0f);
        Destroy(arrowToFire);
    }

    public void RespawnPlayer(){
        transform.position = originalPosition;
    }
}
