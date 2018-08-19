using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public float Speed;
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * Speed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
