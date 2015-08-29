using UnityEngine;
using System.Collections;

public class hanteiDeleteTime : attackRoot {
	
	public float deleteTime = 0.0f;
	private float time = 0.0f;
	private bool sizeMax = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void create(float dtime){
		deleteTime = dtime;
	}
	
	public void setDeleteTime(float dtime){
		deleteTime = dtime;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		//this.transform.localScale.Set (1.0f*steps,2.0f,2.0f);
		if(sizeMax == false){
			this.transform.localScale = (new Vector3(7.0f*time,0.4f,1.0f));
			this.transform.Translate (new Vector3(7.0f*Time.deltaTime,0.0f,0.0f)); 
		}
		if(this.transform.localScale.x >= 1.0f){
			sizeMax = true;
		}
		
		if (time > deleteTime) {
			GameObject.Destroy (this.gameObject);
		}
	}
}
