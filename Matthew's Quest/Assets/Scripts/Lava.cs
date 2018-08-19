using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

	private Player player;

	void Start () {
		
		player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
		Debug.Log (player.name);
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.CompareTag ("player")) {
			player.Damage(5);
			Debug.Log ("Working...");

		}
	}
		
}
