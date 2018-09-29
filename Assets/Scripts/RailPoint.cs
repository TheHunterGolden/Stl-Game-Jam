using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RailPoint : MonoBehaviour {

	[SerializeField]
	private RailPoint nextPoint;
	public RailPoint NextPoint { get {return nextPoint; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
