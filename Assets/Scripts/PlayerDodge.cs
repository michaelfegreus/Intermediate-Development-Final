using UnityEngine;
using System.Collections;

public class PlayerDodge : MonoBehaviour {

	public float moveSpeed;
	public float turnSpeed;
	public float throwSpeed;
	public bool boomerangThrown;
	private float timer = 0f;

	Vector3 returnPos;

	CharacterController cController;
	public GameObject boomerangPrefab;
	public bool applyForce;
	public GameObject spawner;

	Rigidbody rb;

	bool dodging = false;
	float dodgeTimeLimit = .5f;
	float dodgeTimer = dodgeTimeLimit;
	/*float doubleTapLimit = .6f;
	float doubleTapTimer = 0f;
	string lastKey;
	string myUpInput;*/

	void Start () {
		cController = GetComponent<CharacterController>();
		boomerangThrown = false;
		applyForce = false;
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float inputX = Input.GetAxis ("Horizontal"); // A/D, LeftArrow/RightArrow
		float inputY = Input.GetAxis ("Vertical"); // W/S, UpArrow/DownArrow

		rb.velocity = transform.forward * inputY * moveSpeed // forward and back movement

			+ transform.right * inputX * moveSpeed; // left and right movement

			//+ Physics.gravity; // always apply gravity
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			dodging = true;
		}
		if(dodgeTimer < dodgeTimeLimit * (-1f){
			dodgeTimer = dodgeTimeLimit;
		}
		/*
		if (Input.GetKey (KeyCode.W)) {
			if(
			doubleTapTimer = 0f;
		}
		doubleTapTimer = doubleTapTimer + Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.W)) {
			if ((lastKey == "W") && (doubleTapTimer < doubleTapLimit)) {
				Debug.Log ("Double tap");
				rb.velocity = new Vector3 (0f, 0f, 20f);
			} else {
				lastKey = "W";
				doubleTapTimer = 0f;
			}
		}
		doubleTapTimer = doubleTapTimer + Time.deltaTime;*/
	}

	void Update(){

		returnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		/*float inputX = Input.GetAxis ("Horizontal"); // A/D, LeftArrow/RightArrow
		float inputY = Input.GetAxis ("Vertical"); // W/S, UpArrow/DownArrow

		//actually apply movement now
		cController.SimpleMove (transform.forward * inputY * moveSpeed);
		//actually turn the palyer capsule now
		transform.Rotate (0f, inputX * turnSpeed, 0f);*/


		if (Input.GetKeyDown (KeyCode.E) && boomerangThrown == false) {
			applyForce = true;
			GameObject boomerang = (GameObject)Instantiate (boomerangPrefab, spawner.transform.position, Quaternion.identity);

			boomerangThrown = true;

		}
	}
}