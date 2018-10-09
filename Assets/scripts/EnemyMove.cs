using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour {
	private float enemySpeed;
	public Life life;
	public EnemyGenerator enemyGenerator;
	int damage ;

	GameObject target;

	// Use this for initialization
	void Start ()
	{
		switch(gameObject.tag){
		case"Red":
			enemySpeed = 2;
			damage = 1;
			break;
		case"Blue":
			enemySpeed = 3;
			damage = 2;
			break;
		case"Blimp":
			enemySpeed = 1f;
			damage = 19;
			break;
		}

		target = GameObject.FindGameObjectWithTag ("target");

	}
		
	void Update () {
		float step = enemySpeed * Time.deltaTime;
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, step);
	}
		
	void OnCollisionEnter2D(Collision2D coll)
	{
		switch (coll.gameObject.tag) {
		case"target":
			for (int i=0; i < damage;i++){
				life.lostLife ();
			}
			Destroy (gameObject);
			enemyGenerator.BaloonGone ();
			break;
		}
	}
}
