using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour {

    public Text myText;
    public int treehouseHealth = 15;
    // Use this for initialization

    [SerializeField]
    private HPStat health;

    void Start () {
        RefreshText();
	}

    private void Awake()
    {
        health.Initialize();
    }
	
    public void TakeDamage(int damageTaken){
        treehouseHealth -= damageTaken;
        health.CurrentVal = treehouseHealth;
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
