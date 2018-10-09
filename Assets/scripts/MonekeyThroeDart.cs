using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonekeyThroeDart : MonoBehaviour {

	float waitShoot;
	public GameObject dart;
	CurrencyController moneyController;
	int amountToinstantiate;
	float timeToShoot;
	bool increasePower;
	int power;
	// Use this for initialization
	void Start () {
		waitShoot = Time.time ;
		switch(gameObject.tag){
		case "Regular":
			timeToShoot = 4;
			power = 1;
			break;
		case "Wizard":
			timeToShoot = 2;
			power = 2;
			break;
		case "Sun":
			timeToShoot = .5f;
			power = 4;
			break;
		}
		increasePower = false;
		amountToinstantiate = 1;
		moneyController = GameObject.Find ("GameController").GetComponent<CurrencyController> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionStay2D(Collision2D coll) {
		switch (coll.gameObject.tag) {
		case"Red":
		case"Blimp":
		case"Blue":
			Vector3 dir = coll.transform.position - transform.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			if (Time.time > waitShoot) {
				Instantiate (dart, transform.position, transform.rotation, this.gameObject.transform);
				if (amountToinstantiate > 1) {
					Vector2 secondDartPos = new Vector2 (transform.position.x + .3f, transform.position.y);
					Instantiate (dart, secondDartPos, transform.rotation, this.gameObject.transform);
				}
				waitShoot += timeToShoot;
			}
			break;
		}
	}

	//returns true on success
	public bool BuyShootFaster(){
		if ((timeToShoot == 2) &&(moneyController.buyUpgrade())){
			timeToShoot = timeToShoot /2;
			return true;
		}
		return false;
	}

	public bool BuyIncreasePower(){
		if ((increasePower == false) &&(moneyController.buyUpgrade())){
			switch(gameObject.tag){
			case "Regular":
				power += 1;
				break;
			case "Wizard":
				power += 2;
				break;
			case "Sun":
				power += 4;
				break;
			}
			increasePower = true;
			return true;
		}
		return false;
	}

	public bool getIncreasePower(){
		return increasePower;
	}

	public int getpowerIncrease(){
		return power;;
	}

	public bool BuyUpgradeAmount(){
		if ((amountToinstantiate == 1) &&(moneyController.buyUpgrade())){
			amountToinstantiate = 2;
			return true;
		}
		return false;
	}

}
