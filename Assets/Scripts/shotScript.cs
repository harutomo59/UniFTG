using UnityEngine;
using System.Collections;

public class shotScript : MonoBehaviour {
	
	GameObject myself = null;
	public float speed = 10.0f;
	private int testdmg = 10;
	
	public int getTestDmg(){
		return this.testdmg;
	}

	public void setTestDmg(int d){
		this.testdmg = d;
	}
	
	// Use this for initialization
	void Start () {
		this.transform.GetComponent<Rigidbody>().AddForce (new Vector3 (speed, 0, 0));
		myself = this.gameObject;
		Debug.Log ("myself->" + myself.name);
		/*switch (myself.name) {
		case "testshot(Clone)":
			testdmg = 10;
			break;
		case "shot(Clone)":
			testdmg = 3;
			break;
		}*/
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnCollisionEnter(Collision other){
		GameObject.Destroy (myself);
	}
	void OnTriggerEnter(Collider other){
		GameObject.Destroy (myself);
	}
}
