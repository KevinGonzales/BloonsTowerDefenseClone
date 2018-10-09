using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject spawn;
	public GameObject[] enemies;
	public LevelController levelController;
	int left;
	bool hard;
	bool critical;
	// Use this for initialization
	void Start () {
		hard = false;
		critical = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(left <= 0){
			if (critical) {
				StartCoroutine(PassedLevel());
				critical = false;
			}
		}
	}

	IEnumerator PassedLevel()
	{
		yield return new WaitForSecondsRealtime(5);
		critical = true;
		levelController.passedLevel ();
	}

	public void SpawnWave(){
		int level = levelController.getLevel ();
		int amount = level * 5;
		if(amount > 50){
			amount = 50;
			hard = true;
		}
			
		left = amount;
		for(int i = 0; i< amount; i++){
			StartCoroutine(Spawn());
		}
	}

	public void BaloonGone(){
		left--;
	}

	IEnumerator Spawn()
	{
		//print(Time.time);
		int waitTime = Random.Range(0,10);
		yield return new WaitForSecondsRealtime(waitTime);
		int e = 0;
		int i = Random.Range (0,100);
		if (levelController.getLevel () < 4) {
			e = 0;
		} else if (levelController.getLevel () < 11) {
			if (i < 100) {
				e = 1;
			}
			if (i < 70) {
				e = 0;
			}
		} else {
			if(i<100){
				e = 2;
			}
			if(i<90){
				e = 1;
			}
			if(i<60){
				e = 0;
			}
		}

		if(levelController.getLevel () > 22){
			if (i < 90) {
				e = 2;
			} else {
				e = 1;
			}
		}

		if(hard){
			e = 2;
		}

		Instantiate (enemies[e],spawn.transform.position, Quaternion.identity);
		//print(Time.time);
	}
}
