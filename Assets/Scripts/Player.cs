using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;
	public float turnSpeed;
	public float throwSpeed;
	public bool boomerangThrown;
	//private float timer = 0f;

	//Vector3 returnPos;

	CharacterController cController;
	public GameObject boomerangPrefab;
	public bool applyForce;
	public GameObject spawner;

	public string myHorizontalAxis = ("Horizontal");
	public string myVerticalAxis = ("Vertical");

	//Key for throwing boomerang right and left
	public KeyCode myBButtonRight;
	public KeyCode myBButtonLeft;

	//Keys for character movement to determine the direction the player is facing
	public KeyCode myMoveUp;
	public KeyCode myMoveDown;
	public KeyCode myMoveLeft;
	public KeyCode myMoveRight;

	//Bools for deteriming the direction the player is facing
	public bool facingNorth;
	public bool facingEast;
	public bool facingSouth;
	public bool facingWest;
	public bool facingNorthEast;
	public bool facingNorthWest;
	public bool facingSouthEast;
	public bool facingSouthWest;

	void Start () {
		cController = GetComponent<CharacterController>();
		boomerangThrown = false;
		applyForce = false;

	}

	void FixedUpdate () {

	}

	void Update(){

		//returnPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		//float inputX = Input.GetAxis (myHorizontalAxis); // A/D, LeftArrow/RightArrow
		//float inputY = Input.GetAxis (myVerticalAxis); // W/S, UpArrow/DownArrow

		//Up/Down Movement
		//cController.SimpleMove (transform.forward * inputY * moveSpeed);
		//Left/Right Movement
		//cController.SimpleMove (transform.right * inputX * moveSpeed);

		//tank movement
		//transform.Rotate (0f, inputX * turnSpeed, 0f);

		if (Input.GetKey (myMoveUp)) {
			transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey (myMoveDown)) {
			transform.position += Vector3.back * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey (myMoveLeft)) {
			transform.position += Vector3.left * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey (myMoveRight)) {
			transform.position += Vector3.right * Time.deltaTime * moveSpeed;
		}


		//throws the boomerang to the right - currently only goes forward
		if (Input.GetKeyUp (myBButtonRight) && boomerangThrown == false) {
			applyForce = true;
			GameObject boomerang = (GameObject)Instantiate (boomerangPrefab, spawner.transform.position, Quaternion.identity);

			boomerangThrown = true;

		}

		//throws the boomerang to the left 
		if (Input.GetKeyUp (myBButtonLeft) && boomerangThrown == false) {
			
			//boomerangThrown = true;
		}


		//determining the direction the player is facing
		if (Input.GetKey (myMoveUp)) {
			facingNorth = true;
		} else {
			facingNorth = false;
		}

		if (Input.GetKey (myMoveDown)) {
			facingSouth = true;
		} else {
			facingSouth = false;
		}

		if (Input.GetKey (myMoveLeft)) {
			facingWest = true;
		} else {
			facingWest = false;
		}

		if (Input.GetKey (myMoveRight)) {
			facingEast = true;
		} else {
			facingEast = false;
		}

		if (facingNorth == true && facingEast == true) {
			facingNorthEast = true;
			facingNorth = false;
			facingEast = false;
		} else {
			facingNorthEast = false;
		}

		if (facingNorth == true && facingWest == true) {
			facingNorthWest = true;
			facingNorth = false;
			facingWest = false;
		} else {
			facingNorthWest = false;
		}

		if (facingSouth == true && facingEast == true) {
			facingSouthEast = true;
			facingSouth = false;
			facingEast = false;
		} else {
			facingSouthEast = false;
		}

		if (facingSouth == true && facingWest == true) {
			facingSouthWest = true;
			facingSouth = false;
			facingWest = false;
		} else {
			facingSouthWest = false;
		}

		//changing the direction the player is facing

		if (facingNorth == true) {
			//transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
			transform.eulerAngles = new Vector3 (0, 0);
		}

		if (facingEast == true) {
			transform.eulerAngles = new Vector3 (0, 90);
		}

		if (facingSouth == true) {
			transform.eulerAngles = new Vector3 (0, 180);
		}

		if (facingWest == true) {
			transform.eulerAngles = new Vector3 (0, 270);
		}

		if (facingNorthEast == true) {
			transform.eulerAngles = new Vector3 (0, 45);
		}

		if (facingNorthWest == true) {
			transform.eulerAngles = new Vector3 (0, 315);
		}

		if (facingSouthEast == true) {
			transform.eulerAngles = new Vector3 (0, 135);
		}

		if (facingSouthWest == true) {
			transform.eulerAngles = new Vector3 (0, 225);
		}

	}
}