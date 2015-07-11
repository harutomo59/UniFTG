using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	
	public struct Keystate {
		public bool		up;
		public bool		down;
		public bool		right;
		public bool		left;
		public bool		atk1;
		public bool		atk2;
		public bool		atk3;
		public bool		atk4;
		public bool		sp1;
		public bool		sp2;
	};
	
	protected Keystate getInputKye(){
		Keystate s;
		s.up = false;
		s.down = false;
		s.right = false;
		s.left = false;
		s.atk1 = false;
		s.atk2 = false;
		s.atk3 = false;
		s.atk4 = false;
		s.sp1 = false;
		s.sp2 = false;
		
		s.up |= Input.GetKey(KeyCode.UpArrow);
		s.down = Input.GetKey(KeyCode.DownArrow);
		s.right = Input.GetKey(KeyCode.RightArrow);
		s.left = Input.GetKey(KeyCode.LeftArrow);
		s.atk1 = Input.GetKeyDown(KeyCode.S);
		s.atk2 = Input.GetKeyDown(KeyCode.A);
		s.atk3 = Input.GetKeyDown(KeyCode.Q);
		s.atk4 = Input.GetKeyDown(KeyCode.W);
		s.sp1 = Input.GetKeyDown(KeyCode.E);
		s.sp2 = Input.GetKeyDown(KeyCode.D);
		
		return s;
	}
	protected void getInputKye(Keystate s){
		s.up = false;
		s.down = false;
		s.right = false;
		s.left = false;
		s.atk1 = false;
		s.atk2 = false;
		s.atk3 = false;
		s.atk4 = false;
		s.sp1 = false;
		s.sp2 = false;
		
		s.up |= Input.GetKey(KeyCode.UpArrow);
		s.down = Input.GetKey(KeyCode.DownArrow);
		s.right = Input.GetKey(KeyCode.RightArrow);
		s.left = Input.GetKey(KeyCode.LeftArrow);
		s.atk1 = Input.GetKeyDown(KeyCode.S);
		s.atk2 = Input.GetKeyDown(KeyCode.A);
		s.atk3 = Input.GetKeyDown(KeyCode.Q);
		s.atk4 = Input.GetKeyDown(KeyCode.W);
		s.sp1 = Input.GetKeyDown(KeyCode.E);
		s.sp2 = Input.GetKeyDown(KeyCode.D);
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
