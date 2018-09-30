using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RailPoint : InputEventListener {

	[SerializeField]

	public RailPoint nextPoint;

	[SerializeField]
	bool isSwitch;

	public bool IsSwitch { get { return isSwitch; } }

	[SerializeField]
	RailPoint[] Switches;

	public float joystickResetTime;

	public InputCode direction;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public override void RaiseEvent(InputCode ic) {
		nextPoint = Switches[(int) ic];
		StopCoroutine("resetPoint");
		StartCoroutine("resetPoint");
	}

	IEnumerator resetPoint()
	{
		yield return new WaitForSeconds(joystickResetTime);
		nextPoint = this;
		yield return null;
	}

	public void Activate(RailPoint point) {
		if(isSwitch) {
			StopCoroutine("resetPoint");

			nextPoint = null;

			InputManager mgr = (InputManager) GameObject.Find("InputManager").GetComponent("InputManager");

			for(direction = (InputCode) 0; direction < InputCode.Button1 && Switches[(int) direction] != point; direction++) {
			}

			for(InputCode i = (InputCode) 0; i < InputCode.Button1; ++i) {
				if(i != direction && Switches[(int) i] != null) {
					mgr.RegisterListener(this, i);
				}
			}
		}
		else {
			foreach(RailPoint i in Switches) {
				if(i != null && i != point) {
					nextPoint = i;
				}
			}
		}
	}

	public void Deactivate() {
		InputManager mgr = (InputManager) GameObject.Find("InputManager").GetComponent("InputManager");

		for(InputCode i = (InputCode) 0; i < InputCode.Button1; ++i) {
			mgr.DeregisterListener(this, i);
		}

	}

	public void GetPassThru() {
		InputCode passthru = (InputCode) (((int) direction + 2) % (int) InputCode.Button1);
		nextPoint = Switches[(int) passthru];
	}

}
