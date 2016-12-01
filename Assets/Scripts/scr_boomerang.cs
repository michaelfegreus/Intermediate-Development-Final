using UnityEngine;
using System.Collections;

public class scr_boomerang: MonoBehaviour {

	Rigidbody rbody;
	public float timer = 0f;
	float destroyTimer = 3.5f;
	public GameObject player;
	public Vector3 startPoint;
	public bool applyForce;
	public float throwSpeed;
	public GameObject otherPlayer;

	public GameObject p1WinText;
	public GameObject p2WinText;

	public bool snapBack = false;

	// Use this for initialization
	void Start () {
		
		timer = .5f;
		rbody = GetComponent<Rigidbody>();
		//player = GameObject.Find ("Player");
		//player = GameObject.Find ("Player1");
		applyForce = true;
		//startPoint = new Vector3 (3.63f, 0.85f, 6.090801f);
			

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 directionToPlayer = player.transform.position - transform.position;

		timer -= Time.deltaTime;

		if (applyForce == true) {
			GetComponent<Rigidbody> ().velocity = player.transform.forward * throwSpeed;
			//GetComponent<Rigidbody> ().AddForce (player.transform.forward * throwSpeed);
		}
		if (timer <= 0){
			//startPoint = transform.position;
			//Vector3.Lerp (startPoint, player.transform.position, .5f);
			//player.GetComponent<Player> ().applyForce = false;
			applyForce = false;
			rbody.AddForce(directionToPlayer.normalized * (20f + throwSpeed));
			if (snapBack == true) {
				rbody.velocity = Vector3.zero;
				rbody.transform.position += directionToPlayer.normalized * 5f;
			}
		}
		if (destroyTimer < 0) {
			// (gameObject);
		}
		destroyTimer = destroyTimer - Time.deltaTime;
	}

	void OnTriggerEnter (Collider collision){

		if (collision.gameObject ==  player && timer <=0) {
			player.GetComponent<scr_player> ().boomerangThrown = false;
			player.GetComponent<scr_player> ().charge = 0;
			Destroy (gameObject);
		} else if (collision.tag == "Boomerang") {
			Debug.Log ("Hit boomerang of opponent");
		} else if ( collision.tag != player.tag && (collision.tag == "PlayerOne" || collision.tag == "PlayerTwo") ) {
			player.GetComponent<scr_player> ().charge = 0;
			if (collision.tag == "PlayerOne") {
				Instantiate (p2WinText, Vector3.zero , Quaternion.identity);
			}
			else if (collision.tag == "PlayerTwo") {
				Instantiate (p1WinText, Vector3.zero , Quaternion.identity);
			}
			if (collision.gameObject.GetComponent<scr_player> ().dodging == false) {
				Destroy (collision.gameObject);
			}
		}
	}
}
