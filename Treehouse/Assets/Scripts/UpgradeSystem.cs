using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeSystem : MonoBehaviour {

    public GameObject[] turrets = new GameObject[3];
    public int[] upgradeCost = new int[3];
    public GameObject upgradeText;
    public Turret turret;
    public int currentIndex = 1;
    public bool canUpgrade = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(currentIndex < turrets.Length){
            if(Input.GetKeyDown(KeyCode.F) && canUpgrade){
                if(ResourceManager.instance.resources >= upgradeCost[currentIndex]){
                    ResourceManager.instance.SpendResources(upgradeCost[currentIndex]);
                    turrets[currentIndex - 1].SetActive(false);
                    turrets[currentIndex].SetActive(true);
                    currentIndex += 1;
                    turret.Upgrade();
                } 
            }    
        } else{
            canUpgrade = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (currentIndex < turrets.Length)
            {
                if (upgradeCost[currentIndex] <= ResourceManager.instance.resources)
                {
                    upgradeText.SetActive(true);
                    canUpgrade = true;
                }
            }
            else
            {
                canUpgrade = false;
                upgradeText.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (currentIndex < turrets.Length)
            {
                if (upgradeCost[currentIndex] <= ResourceManager.instance.resources)
                {
                    upgradeText.SetActive(true);
                    canUpgrade = true;
                }
            }
            else
            {
                canUpgrade = false;
                upgradeText.SetActive(false);
            }
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            upgradeText.SetActive(false);
            canUpgrade = false;
        }
    }
}
