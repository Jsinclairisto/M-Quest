using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{

	private Player player;



	void start()
	{
		player = gameObject.GetComponentInParent<Player>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if(null == player)
		{
			start();
		}

		player.grounded = true;
	}

	void OnTriggerStay2D(Collider2D col){
	
		player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		player.grounded = false; 
	}



}﻿