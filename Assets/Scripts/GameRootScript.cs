using UnityEngine;
using System.Collections;

public class GameRootScript : Key {
	
	private string mySide = "";
	private GameObject p1 = null;
	private GameObject p2 = null;
	CharactorMove tes1;
	CharactorMove tes2;
	
	// Use this for initialization
	void Start () {
		mySide = "Player1";
		p1 = GameObject.Find ("Player1") as GameObject;
		p2 = GameObject.Find ("Player2") as GameObject;
		
		//if (p1.GetComponent<CharactorMove> != null) {
		tes1 = p1.GetComponent<CharactorMove>();
		if (mySide == "Player1") {
			tes1.setPlayerNumber(mySide);
		}
		tes2 = p2.GetComponent<CharactorMove>();
		//}
	}
	
	// Update is called once per frame
/*	void Update () {
		if (mySide == "Player1") {
			tes1.ta (getInputKye ());
		}

	}
*/
	void FixedUpdate(){
		if (mySide == "Player1") {
			tes1.ta (getInputKye ());
		}
	}
}
