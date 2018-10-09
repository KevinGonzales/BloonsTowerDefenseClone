using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	private int level;
	public	Text textLevel;
	public EnemyGenerator enemyGenerator;
	// Use this for initialization
	void Start () {
		level = 0;
		passedLevel ();
	}
	
	public void passedLevel(){
		level++;
		enemyGenerator.SpawnWave ();
		textLevel.text = "Level: " + level;
	}

	public int getLevel(){
		return level;
	}
}
