using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyController : MonoBehaviour {
	public Text textMoney;
	int money;
	int amountToupgrade;
	int wizardCost;
	int sunMonkeyCost;
	int normalMonkeyCost;
	// Use this for initialization
	void Start () {
		money = 500;
		amountToupgrade = 1000;
		wizardCost = 1000;
		sunMonkeyCost = 3000;
		normalMonkeyCost = 200;
		textMoney.text = "Money: " + money;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncreaseMoney(int amount){
		money += amount;
		textMoney.text = "Money: " + money;
	}
	public void DecreaseMoney(int amount){
		money -= amount;
		textMoney.text = "Money: " + money;
	}

	public int getMoney(){
		return money;
	}

	public bool buyUpgrade(){
		if(money > amountToupgrade){
			money -= amountToupgrade;
			textMoney.text = "Money: " + money;
			return true;
		}
		return false;
	}

	public bool buyNormalMonkey(){
		if(money >= normalMonkeyCost){
			money -= normalMonkeyCost;
			textMoney.text = "Money: " + money;
			return true;
		}
		return false;
	}

	public bool buyWizardMonkey(){
		if (money >= wizardCost) {
			money -= wizardCost;
			textMoney.text = "Money: " + money;
			return true;
		}
		return false;
	}

	public bool buySunMonkey(){
		if (money >= sunMonkeyCost) {
			money -= sunMonkeyCost;
			textMoney.text = "Money: " + money;
			return true;
		}
		return false;
	}
}
