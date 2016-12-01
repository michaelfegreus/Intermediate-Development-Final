using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scr_player : MonoBehaviour {

	public int playerNumber;

	Rigidbody rb;

	public float baseMoveSpeed;
	float currentMoveSpeed;
	public float halfMoveSpeed;
	public float turnSpeed;
	public float throwSpeed;
	public float charge;
	public bool boomerangThrown;

	public GameObject boomerangPrefab;
	public bool applyForce;
	public GameObject spawner;

	public string myHorizontalAxis = ("Horizontal");
	public string myVerticalAxis = ("Vertical");

	//Key for throwing boomerang right and left
	public KeyCode myBButtonRight;
	public KeyCode myBButtonLeft;

	//Key for dodging
	public KeyCode myDodgeButton;

	//Keys for character movement to determine the direction the player is facing
	public KeyCode myMoveUp;
	public KeyCode myMoveDown;
	public KeyCode myMoveLeft;
	public KeyCode myMoveRight;

	//Bools for deteriming the direction the player is facing
	bool facingNorth;
	bool facingEast;
	bool facingSouth;
	bool facingWest;
	bool facingNorthEast;
	bool facingNorthWest;
	bool facingSouthEast;
	bool facingSouthWest;

	public bool dodging = false;
	float dodgeTimeLimit = .5f;
	float dodgeTimer;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		boomerangThrown = false;
		applyForce = false;
		currentMoveSpeed = baseMoveSpeed;
		dodgeTimer = dodgeTimeLimit;
		if (playerNumber == 1) {
			gameObject.name = "Player1";
		}
		if (playerNumber == 2) {
			gameObject.name = "Player2";
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			SceneManager.LoadScene (0);
		}
	}

	void FixedUpdate(){
		if (((playerNumber == 1) && (Input.GetKeyDown (KeyCode.LeftShift))) || ((playerNumber == 2) && (Input.GetKeyDown (KeyCode.RightShift)))) {
			if ((0 < dodgeTimer)&&(!dodging)) {
				dodging = true;
				rb.velocity = Vector3.zero;
				rb.AddForce(Vector3.right);

			}
		}
		if ((dodging)||(dodgeTimer <= 0)) {
			dodgeTimer = dodgeTimer - Time.deltaTime;
		}
		if (dodgeTimer <= 0) {
			dodging = false;
			rb.velocity = Vector3.zero;
		}
		if(dodgeTimer < (dodgeTimeLimit * (-1f))){
			dodgeTimer = dodgeTimeLimit;
		}
		if (Input.GetKey (myMoveUp)) {
			transform.position += Vector3.forward * Time.deltaTime * currentMoveSpeed;
		}

		if (Input.GetKey (myMoveDown)) {
			transform.position += Vector3.back * Time.deltaTime * currentMoveSpeed;
		}

		if (Input.GetKey (myMoveLeft)) {
			transform.position += Vector3.left * Time.deltaTime * currentMoveSpeed;
		}

		if (Input.GetKey (myMoveRight)) {
			transform.position += Vector3.right * Time.deltaTime * currentMoveSpeed;
		}

		if (Input.GetKey (myBButtonRight) && boomerangThrown == false && charge < 12) {
			charge += 4 * Time.deltaTime;
			Debug.Log (charge);
		}
		//throws the boomerang to the right - currently only goes forward
		if (Input.GetKeyUp (myBButtonRight) && boomerangThrown == false) {
			applyForce = true;
			GameObject boomerang = (GameObject)Instantiate (boomerangPrefab, spawner.transform.position, Quaternion.identity);
			boomerang.GetComponent<scr_boomerang> ().player = gameObject;
			boomerang.GetComponent<scr_boomerang> ().throwSpeed = 7f + charge;
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
			//currentMoveSpeed = baseMoveSpeed;
		}

		if (facingEast == true) {
			transform.eulerAngles = new Vector3 (0, 90);
			//currentMoveSpeed = baseMoveSpeed;
		}

		if (facingSouth == true) {
			transform.eulerAngles = new Vector3 (0, 180);
			//currentMoveSpeed = baseMoveSpeed;
		}

		if (facingWest == true) {
			transform.eulerAngles = new Vector3 (0, 270);
			//currentMoveSpeed = baseMoveSpeed;
		}

		if (facingNorthEast == true) {
			rb.velocity = new Vector3 (currentMoveSpeed, 0f, currentMoveSpeed);

			transform.eulerAngles = new Vector3 (0, 45);
			//currentMoveSpeed = currentMoveSpeed /2f;
			//currentMoveSpeed = halfMoveSpeed;
		}

		if (facingNorthWest == true) {
			rb.velocity = new Vector3 (-(currentMoveSpeed), 0f, currentMoveSpeed);

			transform.eulerAngles = new Vector3 (0, 315);
			//currentMoveSpeed = currentMoveSpeed / 2f;
			//currentMoveSpeed = halfMoveSpeed;
		}

		if (facingSouthEast == true) {
			rb.velocity = new Vector3 (currentMoveSpeed, 0f, -(currentMoveSpeed));

			transform.eulerAngles = new Vector3 (0, 135);
			//currentMoveSpeed = currentMoveSpeed / 2f;
			//currentMoveSpeed = halfMoveSpeed;
		}

		if (facingSouthWest == true) {
			rb.velocity = new Vector3 (-(currentMoveSpeed), 0f, -(currentMoveSpeed));

			transform.eulerAngles = new Vector3 (0, 225);
			//currentMoveSpeed = currentMoveSpeed / 2f;
			//currentMoveSpeed = halfMoveSpeed;
		}


		if (facingNorthEast == true || facingNorthWest == true || facingSouthEast == true || facingSouthWest == true) {

			currentMoveSpeed = halfMoveSpeed;

		} else {
			currentMoveSpeed = baseMoveSpeed;
		}

	}
	/*IEnumerator doubleTapCoroutine(){
		Debug.Log ("The coroutine started!");
		yield return 0; // Wait one frame.
		Debug.Log ("After it waits a frame, it continues and keeps going with the function.");
		// If you have to wait more frames, you have to add more yields.
		yield return 0;
		yield return 0; //yield return 1; or yield return null; would do the same thing as yield return 0;
		yield return new WaitForSeconds(1f); // Wait for one second.
		Debug.Log("I waited for one second!");
	}*/
}