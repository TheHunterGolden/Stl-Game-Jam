using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputManager : MonoBehaviour {

	[SerializeField]
	public InputEvent[] inputs;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Up")) {
			inputs[(int) InputCode.Up].Raise();
		}
		if(Input.GetButtonDown("Down")) {
			inputs[(int) InputCode.Down].Raise();
		}
		if(Input.GetButtonDown("Left")) {
			inputs[(int) InputCode.Left].Raise();
		}
		if(Input.GetButtonDown("Right")) {
			inputs[(int) InputCode.Right].Raise();
		}
		if(Input.GetButtonDown("Blue1")) {
			inputs[(int) InputCode.Button1].Raise();
		}
		if(Input.GetButtonDown("Red2")) {
			inputs[(int) InputCode.Button2].Raise();
		}
	}

	public void RegisterListener(InputEventListener listener, InputCode ic) {
		inputs[(int) ic].RegisterListener(listener);
	}

	public void DeregisterListener(InputEventListener listener, InputCode ic) {
		inputs[(int) ic].DeregisterListener(listener);
	}
}
