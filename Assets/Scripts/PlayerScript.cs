using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	Rigidbody rbody;
	public float moveSpeed;

	public Transform boomerangSpawnpoint;
	public GameObject boomerangPrefab;
	//GameObject currentBoomerang;
	Vector3 spawnPos;
	bool boomerangThrown;

	void OnTriggerEnter(Collider col) {
		if (col.tag == ("Boomerang")) {
			Destroy (col);
			boomerangThrown = false;
		}
	}

	void Start () {
		rbody = GetComponent<Rigidbody>();
		boomerangThrown = false;
	}
		
	void FixedUpdate () {

		float inputX = Input.GetAxis( "Horizontal" ); // A/D, LeftArrow/RightArrow
		float inputZ= Input.GetAxis( "Vertical" ); // W/S, UpArrow/DownArrow

		rbody.velocity = transform.forward * inputZ * moveSpeed // forward and back movement

			+ transform.right * inputX * moveSpeed; // left and right movement

			//+ Physics.gravity; // always apply gravity

	}

	void Update(){
		if (Input.GetKey (KeyCode.E)) {
			spawnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			boomerangThrown = true;
			Instantiate (boomerangPrefab, spawnPos, Quaternion.identity);
		}
	}
}