using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera _camera;
    public float moveSpeed;
    public GameObject turret;


	// Use this for initialization
	void Start () {
        moveSpeed = 5f;
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



	}
}
