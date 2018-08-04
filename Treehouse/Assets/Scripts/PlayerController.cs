using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera _camera;
    public float moveSpeed;
    public GameObject turret, arrow;
    ArrowStateMachine _ASM;
    Vector3 originalPosition;


	// Use this for initialization
	void Start () {
        moveSpeed = 5f;
        _ASM = arrow.GetComponent<ArrowStateMachine>();
        originalPosition = transform.position;
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

        if (Input.GetKeyDown(KeyCode.F)){
            GameObject spawn = Instantiate(turret);
            spawn.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && _ASM._state == ArrowStateMachine.State.ready){
            
        }




	}

    public void RespawnPlayer(){
        transform.position = originalPosition;
    }
}
