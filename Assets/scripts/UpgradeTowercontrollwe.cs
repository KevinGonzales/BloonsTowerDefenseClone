using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeTowercontrollwe : MonoBehaviour {

	GameObject tower;
	GameObject Range;

	// Use this for initialization
	void Start () {
		tower = null;
		Range = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setCurrentTower(GameObject tower){

		if(Range){
			Range.SetActive(false);
		}
			
		this.tower = tower;
		Range = tower.transform.parent.Find ("Range").gameObject;
		Range.SetActive(true);
	}

	public void disableRange(){
		if(Range)
		Range.SetActive(false);
	}

	public void UpgradeSpeed(){
		try{
			if (tower ) {
				MonekeyThroeDart monkeyThrowDart = tower.GetComponent<MonekeyThroeDart> ();
				if (monkeyThrowDart.BuyShootFaster ()) {

				}
			}
		}
		catch(Exception e){
			
		}

	}

	public void UpgradeAmount(){
		try{
			if (tower) {
				MonekeyThroeDart monkeyThrowDart = tower.GetComponent<MonekeyThroeDart> ();
				if (monkeyThrowDart.BuyUpgradeAmount ()) {

				}
			}
		}
		catch(Exception e){
			
		}

	}

	public void UpgradePower(){
		try{
			if (tower) {
				MonekeyThroeDart monkeyThrowDart = tower.GetComponent<MonekeyThroeDart> ();
				if (monkeyThrowDart.BuyIncreasePower ()) {

				}
			}
		}catch(Exception e){
			
		}

	}
}
