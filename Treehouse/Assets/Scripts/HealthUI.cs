using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour {

    public Text myText;
    public int treehouseHealth = 100;
	// Use this for initialization
	void Start () {
        RefreshText();
	}
	
    public void TakeDamage(int damageTaken){
        treehouseHealth -= damageTaken;
        RefreshText();
    }

    void RefreshText(){
        myText.text = "Treehouse health: " + treehouseHealth.ToString();
    }

    private void Update()
    {
        if(treehouseHealth <= 0){
            SceneManager.LoadScene("Game Over");
        }
    }


}
