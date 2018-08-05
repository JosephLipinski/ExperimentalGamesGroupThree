using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;
    public Text myText;
    public int resources = 0;

    // Use this for initialization

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if(instance != this){
            Destroy(gameObject);
        }
    }

    void Start () {
        RefreshText();
	}
	
    public void GainResources(int _resource){
        resources += _resource;
        RefreshText();
    }

    public void SpendResources(int _resource){
        resources -= _resource;
        RefreshText();
    }

    void RefreshText(){
        myText.text = "Resources: " + resources.ToString();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
