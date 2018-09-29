using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ball : MonoBehaviour {

	[SerializeField]
	private RailPoint targetRailPoint;
	[SerializeField]
	private Vector3 dir;
	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		getNextPoint();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		transform.Translate(dir * speed);
		if((targetRailPoint.transform.position - transform.position).sqrMagnitude < (dir * speed).sqrMagnitude) {
			transform.SetPositionAndRotation(targetRailPoint.transform.position, Quaternion.identity);
			getNextPoint();
		}
	}

	private void getNextPoint()
	{
		targetRailPoint = targetRailPoint.NextPoint;
		dir = targetRailPoint.transform.position - transform.position ;
		dir.Normalize();
	}
}
