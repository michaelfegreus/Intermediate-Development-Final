using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

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

	void Start () {
		cController = GetComponent<CharacterController>();
		boomerangThrown = false;
		applyForce = false;

	}

	void FixedUpdate () {

	}

	void Update(){

		returnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		float inputX = Input.GetAxis ("Horizontal"); // A/D, LeftArrow/RightArrow
		float inputY = Input.GetAxis ("Vertical"); // W/S, UpArrow/DownArrow

		//actually apply movement now
		cController.SimpleMove (transform.forward * inputY * moveSpeed);
		//actually turn the palyer capsule now
		transform.Rotate (0f, inputX * turnSpeed, 0f);


		if (Input.GetKeyDown (KeyCode.E) && boomerangThrown == false) {
			applyForce = true;
			GameObject boomerang = (GameObject)Instantiate (boomerangPrefab, spawner.transform.position, Quaternion.identity);

			boomerangThrown = true;

		}
	}
}