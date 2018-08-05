using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStateMachine : MonoBehaviour {
    
    public enum State{
        ready,
        fire,
        collided
    }

    public State _state;

	// Use this for initialization
	void Start () {
        _state = ArrowStateMachine.State.ready;
	}


}
