using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Life : MonoBehaviour {

	private int life;
	public Text textLife;
	public GameObject buttonGameOver;
	// Use this for initialization
	void Start () {
		life = 20;
		textLife.text = "Life: " + life;
	}
	
	// Update is called once per frame
	void Update () {
		if(life <=0){
			//lost
			buttonGameOver.SetActive(true);
			textLife.text = "Life: 0";
		}
			
	}

	public int getLife(){
		return life;
	}
	public void lostLife(){
		life--;
		textLife.text = "Life: " + life;
	}
}
