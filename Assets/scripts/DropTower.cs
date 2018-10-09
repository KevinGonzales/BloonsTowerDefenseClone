using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTower : MonoBehaviour {

	public GameObject[] Towers;
	public GameObject[] towersShades;
	GameObject Tower;
	string tittle;
	UpgradeTowercontrollwe towerController;
	CurrencyController currencyController;
	bool none;

	// Use this for initialization
	void Start () {
		towerController = GameObject.Find ("GameController").GetComponent<UpgradeTowercontrollwe> ();
		currencyController = GameObject.Find ("GameController").GetComponent<CurrencyController> ();
		none = true;
		tittle = "none";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			// Whatever you want it to do.
			towerController.disableRange();
			if(!none)
			{
				bool logic = false;
				switch(tittle){
				case "normal":
					logic = currencyController.buyNormalMonkey ();
					break;
				case "sun":
					logic = currencyController.buySunMonkey ();
					break;
				case "wizard":
					logic = currencyController.buyWizardMonkey ();
					break;
				}
				if (logic) {
					Vector3 pz = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Vector2 pos = new Vector2 (pz.x, pz.y);
					Instantiate (Tower, pos, Quaternion.identity);
					None ();
				} else
					None ();
			}
		}
	}

	public void SelectNormalMonkey(){
		none = false;
		tittle = "normal";
		Tower = Towers[0];
		towersShades[0].SetActive(false);
		towersShades[1].SetActive(true);
		towersShades[2].SetActive(true);
	}
	public void SelectWizardMonkey(){
		none = false;
		tittle = "wizard";
		Tower = Towers[1];
		towersShades[0].SetActive(true);
		towersShades[1].SetActive(false);
		towersShades[2].SetActive(true);
	}
	public void SelectSunMonkey(){
		none = false;
		tittle = "sun";
		Tower = Towers[2];
		towersShades[0].SetActive(true);
		towersShades[1].SetActive(true);
		towersShades[2].SetActive(false);
	}

	public void None(){
		none = true;
		tittle = "none";
		towersShades[0].SetActive(true);
		towersShades[1].SetActive(true);
		towersShades[2].SetActive(true);
	}
}
