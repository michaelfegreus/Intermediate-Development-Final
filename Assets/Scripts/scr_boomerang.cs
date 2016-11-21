using UnityEngine;
using System.Collections;

public class scr_boomerang: MonoBehaviour {

	Rigidbody rbody;
	public float timer = 0f;
	public GameObject player;
	public Vector3 startPoint;
	public bool applyForce;
	public float throwSpeed;


	// Use this for initialization
	void Start () {
		throwSpeed = 25f;
		timer = .75f;
		rbody = GetComponent<Rigidbody>();
		player = GameObject.Find ("Player1");
		applyForce = true;
		//startPoint = new Vector3 (3.63f, 0.85f, 6.090801f);
			

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 directionToPlayer = player.transform.position - transform.position;

		timer -= Time.deltaTime;

		if (applyForce == true) {
			GetComponent<Rigidbody> ().AddForce (player.transform.forward * throwSpeed);
			//transform.position += player.transform.forward * 10f * Time.deltaTime;
		} else {
		}
		if (timer <= 0){
			//startPoint = transform.position;
			//Vector3.Lerp (startPoint, player.transform.position, .5f);
			//player.GetComponent<Player> ().applyForce = false;
			applyForce = false;
			rbody.AddForce(directionToPlayer.normalized * 50f);
		}
	}

	void OnTriggerEnter (Collider collision){
		if (collision.gameObject.name == "Player" && timer <=0) {
			player.GetComponent<scr_player> ().boomerangThrown = false;
			Destroy (gameObject);
		}

	}
}
