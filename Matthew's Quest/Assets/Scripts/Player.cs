using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 3;
	public float speed = 50f;
	public float jumpPower = 150f;

	public bool grounded;

	public bool onLadder;

	public int curHealth;
	public int maxHealth = 5;

	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	private Rigidbody2D rb2d;
	private Animator anim;

	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		gravityStore = rb2d.gravityScale;

		curHealth = maxHealth;
	}

	void Update () {

		anim.SetBool ("Grounded",grounded);
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

		if (Input.GetAxis ("Horizontal") < -0.1f) {
		
			transform.localScale = new Vector3 (-2, 2, 2);

		}

		if (Input.GetAxis ("Horizontal") > 0.1f) {

			transform.localScale = new Vector3 (2, 2, 2);

		}

		if (grounded && Input.GetButtonDown ("Jump")) {
		
			rb2d.AddForce (Vector2.up * jumpPower);
			grounded = false;
		}

		if (onLadder && Input.GetAxis("Vertical") != 0) {
		
			rb2d.gravityScale = 0f;

			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");

			GetComponent<Rigidbody2D> ().gravityScale = climbVelocity;

			rb2d.velocity = new Vector2 (rb2d.velocity.x, climbVelocity);
		
		}

		if (!onLadder && Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) {

			GetComponent<Rigidbody2D>().gravityScale = gravityStore;
		}

		if (onLadder && Input.GetButtonDown ("Jump")) {
			rb2d.AddForce (Vector2.up * jumpPower);
			grounded = false;
		}

		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		if (curHealth <= 0) {

			Die();

		}
	}

	void FixedUpdate(){

		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		float h = Input.GetAxis ("Horizontal");

		//Fake Friction / Easing the x speed of out player

		if (grounded) {

			rb2d.velocity = easeVelocity;
		
		}

		rb2d.AddForce ((Vector2.right * speed) * h);

		if (rb2d.velocity.x > maxSpeed) {
		
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		
		}

		if (rb2d.velocity.x < -maxSpeed) {
		
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		
		}


	}

	void Die(){
		//restart
		Application.LoadLevel (Application.loadedLevel);

	}

	public void Damage(int dmg){
		curHealth -= dmg; 

	}
}
