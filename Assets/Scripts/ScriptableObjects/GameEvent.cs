using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent : ScriptableObject {

	protected List<GameEventListener> listeners = new List<GameEventListener>();

	public void Awake() {
		listeners.Clear();
	}

	public void RegisterListener(GameEventListener listener) {
		listeners.Add(listener);
	}

	public void DeregisterListener(GameEventListener listener) {
		listeners.Remove(listener);
	}

	public abstract void Raise() ;

}
