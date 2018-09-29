using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InputCode {
	Up,
	Down,
	Left,
	Right,
	Button1,
	Button2,
	NumInputCodes
}

[System.Serializable][CreateAssetMenu]
public class InputEvent : GameEvent {
	[SerializeField]
	private InputCode inputCode;

	public override void Raise() {
		foreach(InputEventListener i in listeners) {
			i.RaiseEvent(inputCode);
		}
	}
}
