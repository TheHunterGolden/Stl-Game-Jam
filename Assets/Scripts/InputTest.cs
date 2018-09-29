using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : InputEventListener {

	// Use this for initialization
	void Start () {

		InputManager mgr = (InputManager) GameObject.Find("InputManager").GetComponent("InputManager");

		mgr.RegisterListener(this, InputCode.Up);
		mgr.RegisterListener(this, InputCode.Down);
		mgr.RegisterListener(this, InputCode.Left);
		mgr.RegisterListener(this, InputCode.Right);
		mgr.RegisterListener(this, InputCode.Button1);
		mgr.RegisterListener(this, InputCode.Button2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void RaiseEvent(InputCode ic) {
		if(ic == InputCode.Up) {
			Debug.Log("UP!");
		}
		if(ic == InputCode.Down) {
			Debug.Log("DOWN!");
		}
		if(ic == InputCode.Left) {
			Debug.Log("LEFT!");
		}
		if(ic == InputCode.Right) {
			Debug.Log("RIGHT!");
		}
		if(ic == InputCode.Button1) {
			Debug.Log("BLUE!");
		}
		if(ic == InputCode.Button2) {
			Debug.Log("RED!");
		}
	}

}
