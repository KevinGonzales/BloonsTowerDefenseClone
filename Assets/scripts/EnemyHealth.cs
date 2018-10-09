using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	
	private int enemyHealth;
	public CurrencyController currecnyController;
	public EnemyGenerator enemyGenerator;

	// Use this for initialization
	void Start () {
		switch(gameObject.tag){
		case"Red":
			enemyHealth = 1;
			break;
		case"Blue":
			enemyHealth = 2;
			break;
		case"Blimp":
			enemyHealth = 200;
			break;
		}
	}
	
	public void gotHit(){
		enemyHealth--;
		currecnyController.IncreaseMoney (10);
		if(enemyHealth<=0){
			Destroy (gameObject);
			currecnyController.IncreaseMoney (50);
			enemyGenerator.BaloonGone();
		}
	}
}
