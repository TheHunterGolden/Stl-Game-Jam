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
	private float mainSpeed;
	private float speed;

	// Use this for initialization
	void Awake () {
		getDirectionVec(null);
		speed = mainSpeed;
	}
	
    public Vector3 getDir()
    {
        return dir;
    }

    public float getSpeed()
    {
        return speed;
    }

    // Update is called once per frame
    void Update () {
		
	}

	void FixedUpdate() {
		transform.Translate(dir * speed);
		if((targetRailPoint.transform.position - transform.position).sqrMagnitude <= (dir * speed).sqrMagnitude) {
			transform.SetPositionAndRotation(targetRailPoint.transform.position, Quaternion.identity);
			if(!checkSameNextPoint()){
				getNextPoint();
			}
		}
	}

	private void getNextPoint() {
		RailPoint last = targetRailPoint;
		targetRailPoint = targetRailPoint.nextPoint;

		getDirectionVec(last);
	}

	private void getDirectionVec(RailPoint last) {
		targetRailPoint.Activate(last);
		dir = targetRailPoint.transform.position - transform.position ;
		dir.Normalize();
	}

	private bool checkSameNextPoint() {
		if(targetRailPoint.nextPoint == null) {
			speed = 0;
			return true;
		}
		else {
			targetRailPoint.Deactivate();
			speed = mainSpeed;
			return false;
		}
	}
}
