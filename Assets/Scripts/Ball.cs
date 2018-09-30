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
	void Start () {
		getNextPoint();
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
			getNextPoint();
		}
	}

	private void getNextPoint() {
		bool test = checkSameNextPoint();
		targetRailPoint = targetRailPoint.nextPoint;
		if(!test) {
			targetRailPoint.Activate();
			dir = targetRailPoint.transform.position - transform.position ;
			dir.Normalize();
		}
	}

	private bool checkSameNextPoint() {
		if(targetRailPoint == targetRailPoint.nextPoint) {
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
