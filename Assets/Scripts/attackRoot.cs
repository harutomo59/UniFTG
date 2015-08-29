using UnityEngine;
using System.Collections;

public class attackRoot : MonoBehaviour {
	
	protected float dmg;
	protected float dTime;
	protected float stiffTime;
	protected float huttobiDir;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void setDTime(float t){
		this.dTime = t;
	}
	
	public void setDmg(float d){
		this.dmg = d;
	}
	public float getDmg(){
		return this.dmg;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
