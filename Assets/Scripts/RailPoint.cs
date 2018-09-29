using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RailPoint : InputEventListener {

	public RailPoint nextPoint;

	[SerializeField]
	bool isSwitch;

	[SerializeField]
	private RailPoint switchClock;
	[SerializeField]
	private RailPoint switchCounter;
	[SerializeField]
	private RailPoint switchPassThru;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void RaiseEvent(InputCode ic) {
		if(ic == InputCode.Up) {
			nextPoint = switchCounter;
		}
		else if(ic == InputCode.Right) {
			nextPoint = switchPassThru;
		}
		else if(ic == InputCode.Down) {
			nextPoint = switchClock;
		}
	}

	public void Activate() {
		if(isSwitch) {
			InputManager mgr = (InputManager) GameObject.Find("InputManager").GetComponent("InputManager");

			if(switchCounter != null) {
				nextPoint = this;
				mgr.RegisterListener(this, InputCode.Up);
			}

			if(switchClock != null) {
				nextPoint = this;
				mgr.RegisterListener(this, InputCode.Down);
			}

			if(switchPassThru != null) {
				nextPoint = switchPassThru;
				mgr.RegisterListener(this, InputCode.Right);
			}
		}
	}

	public void Deactivate() {
		InputManager mgr = (InputManager) GameObject.Find("InputManager").GetComponent("InputManager");

		if(switchCounter != null) {
			mgr.DeregisterListener(this, InputCode.Up);
		}

		if(switchClock != null) {
			mgr.DeregisterListener(this, InputCode.Down);
		}

		if(switchPassThru != null) {
			mgr.DeregisterListener(this, InputCode.Right);
		}
	}
}
