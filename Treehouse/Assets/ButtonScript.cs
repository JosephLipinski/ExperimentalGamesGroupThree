using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Controls(){
        SceneManager.LoadScene("Controls");  
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void MainMenu(){
        SceneManager.LoadScene("Start Screen");
    }

}
