using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : MonoBehaviour {
	UpgradeTowercontrollwe controller;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("GameController").GetComponent<UpgradeTowercontrollwe> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			// Whatever you want it to do.
			controller.setCurrentTower (gameObject.transform.GetChild(0).gameObject); 
		}

	}


}
