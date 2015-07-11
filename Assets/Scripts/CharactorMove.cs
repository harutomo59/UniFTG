using UnityEngine;
using System.Collections;

public class CharactorMove : Key {
	
	private string playerNumber = "";
	private string enemyNumber = "";
	public float moveSpeed = 3.0f;
	public float jumpPower = 300.0f;
	
	public GameObject atk1 = null;
	public GameObject atk2 = null;
	public GameObject atk3 = null;
	
	private bool onGround = false;
	private bool atLeft = true;
	
	private float forwardSpeed = 1.0f;
	private float backSpeed = 0.75f;
	
	private float actionTime = 0.0f;
	private float actionTimeLimit = 0.0f;
	
	private Vector3 keepMoving = Vector3.zero;
	
	enum STATE{
		NONE,
		NORMAL,
		JUMP,
		DASH,
		DASH_JUMP,
		ATTACK,
		STIFF,
		NUM
	};
	STATE now_step=STATE.NONE;
	STATE next_step=STATE.NONE;
	
	public void ta(Keystate keyinput){
		checkSide ();
		now_step = next_step;
		next_step = STATE.NONE;
		
		if (now_step == STATE.ATTACK) {
			actionTime += Time.deltaTime;
			if (actionTime < actionTimeLimit) {
				next_step = STATE.ATTACK;
			}
		} else if (now_step == STATE.JUMP) {
			if (onGround == false) {
				next_step = STATE.JUMP;
			}
		} else if (now_step == STATE.DASH_JUMP) {
			if (onGround == false) {
				next_step = STATE.DASH_JUMP;
				this.transform.Translate (this.keepMoving);
			}else{
				this.keepMoving = Vector3.zero;
			}
		} else
		if (now_step == STATE.NORMAL || now_step == STATE.DASH) {
			
			if (keyinput.atk3) {
				GameObject g = GameObject.Instantiate (this.atk3) as GameObject;
				//g.transform.parent = this.transform;
				g.transform.position = this.transform.position;
				g.transform.Translate (new Vector3 (1.5f, 1.5f, 0.0f));
				actionTime = 0.0f;
				actionTimeLimit = 0.4f;
				setNext (STATE.ATTACK);
			}
			
			if (keyinput.up == true) {
				if(setNext (STATE.JUMP)){
					//this.transform.Translate (Vector3.up * Time.deltaTime * jumpPower);
					this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
					onGround = false;
					if(now_step == STATE.DASH){
						if(keyinput.right == true){
							if(atLeft == true) this.keepMoving = (Vector3.forward * Time.deltaTime * moveSpeed * forwardSpeed);
							else this.keepMoving = (Vector3.back * Time.deltaTime * moveSpeed * backSpeed);
							next_step = STATE.DASH_JUMP;
						}else if(keyinput.left == true){
							if(atLeft == true) this.keepMoving = (Vector3.back * Time.deltaTime * moveSpeed * backSpeed);
							else this.keepMoving = (Vector3.forward * Time.deltaTime * moveSpeed * forwardSpeed);
							next_step = STATE.DASH_JUMP;
						}
					}
					//Debug.Log ("Jump IN");
					//this.rigidbody.velocity.Set (0.0f,10.0f,0.0f);
					//velocity.y = 10.0f;
					//this.rigidbody.velocity = velocity;
					//if(next_step == STATE.NONE)next_step = STATE.JUMP;
				}
			}
			if (keyinput.right == true) {
				if(setNext (STATE.DASH)){
					if(atLeft == true) this.transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed * forwardSpeed);
					else this.transform.Translate (Vector3.back * Time.deltaTime * moveSpeed * backSpeed);
				}
			}
			if (keyinput.left == true) {
				if(setNext (STATE.DASH)){
					if(atLeft == true) this.transform.Translate (Vector3.back * Time.deltaTime * moveSpeed * backSpeed);
					else this.transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed * forwardSpeed);
				}
			}
			
			
			
			
		}
		
		setNext (STATE.NORMAL);
	}
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.name == "Floor") {
			onGround = true;
			//Debug.Log("floorON");
		}
	}
	
	public string getPlayerNumber(){
		return this.playerNumber;
	}
	
	public void setPlayerNumber(string num){
		this.playerNumber = num;
		if (num == "Player1")
			this.enemyNumber = "Player2";
		else if (num == "Player2")
			this.enemyNumber = "Player1";
		
	}
	
	private void checkSide(){
		float myX = this.transform.position.x;
		GameObject enemy = GameObject.Find (enemyNumber) as GameObject;
		float eneX = enemy.transform.position.x;
		//Debug.Log ("Checking Side");
		
		if (myX < eneX) {
			if(atLeft == false){
				//右側から左側へ
				Debug.Log ("Right to Left");
				atLeft = true;
				this.transform.Rotate (0.0f, 180.0f, 0.0f);
				this.keepMoving *= -1;
			}
		} else {
			if(atLeft == true){
				//左側から右側へ
				Debug.Log ("Left to Right");
				atLeft = false;
				this.transform.Rotate (0.0f, 180.0f, 0.0f);
				this.keepMoving *= -1;
			}
		}
	}
	
	private bool setNext(STATE next){
		if (this.next_step == STATE.NONE) {
			this.next_step = next;
			return true;
		}
		return false;
	}
	
}
