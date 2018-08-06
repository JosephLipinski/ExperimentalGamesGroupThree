using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera _camera;
    public float moveSpeed;
    public GameObject turret, arrow, arrowToFire;
    Arrow _arrow;
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
        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Mouse0)){
            if(arrowToFire == null){
                arrowToFire = Instantiate(arrow);
                arrowToFire.transform.SetParent(GameObject.Find("Player/Main Camera/Arrow Position").transform);
                _arrow = arrowToFire.GetComponent<Arrow>();
                arrowToFire.transform.localScale = new Vector3(0.4f, 0.4f, 0.6f);
                arrowToFire.transform.position = GameObject.Find("Player/Main Camera/Arrow Position").transform.position;
                arrowToFire.transform.Translate(Vector3.up * transform.rotation.y, Space.Self);
            } else {
                _arrow.IncreaseThrust();
            }
        }
        if(Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Mouse0)){
            if(arrowToFire != null){
                arrowToFire.transform.SetParent(null);
                _arrow.FireArrow();
            }

        }
	}

    public void RespawnPlayer(){
        transform.position = originalPosition;
    }


}
