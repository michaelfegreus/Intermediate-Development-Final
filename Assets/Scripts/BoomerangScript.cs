using UnityEngine;
using System.Collections;

public class BoomerangScript : MonoBehaviour {

	Rigidbody rbody;
	private float moveSpeed = 20f;
	private float timer = 0f;
	private bool findPlayer;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody>();
		findPlayer = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rbody.velocity = transform.forward * moveSpeed;
		timer = timer + Time.deltaTime;
		if (1.5 < timer) {
			findPlayer = true;
		}
		if (10f < timer) {
			Destroy (gameObject); // If it's out too long
		}
	}
}