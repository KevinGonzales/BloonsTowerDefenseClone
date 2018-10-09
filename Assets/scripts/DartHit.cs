using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartHit : MonoBehaviour {

	void Update(){
		transform.position += transform.up * Time.deltaTime * 2f;
		if(transform.position.y > 100){Destroy (this.gameObject);}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		switch (coll.gameObject.tag) {
		case"Red":
		case"Blimp":
		case"Blue":
			EnemyHealth eHealth = coll.gameObject.GetComponent<EnemyHealth> ();
			MonekeyThroeDart parent = gameObject.GetComponentInParent <MonekeyThroeDart>();
			for (int i = 0; i < parent.getpowerIncrease (); i++) {
					eHealth.gotHit ();
			}
						
			gameObject.GetComponentInParent<AudioSource> ().Play (); 
			Destroy (gameObject);
			break;
		}
	}
}
