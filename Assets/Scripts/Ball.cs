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

	public float passthrutime;
	bool hit;

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
			hit = true;
		}
		if(hit) {
			if(!checkSameNextPoint()){
				getNextPoint();
			}
			else {
				StartCoroutine("Passthru");
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
			return true;
		}
		else {
			speed = mainSpeed;
			return false;
		}
	}

	IEnumerator Passthru() {
		yield return new WaitForSeconds(passthrutime);
		hit = false;
		targetRailPoint.GetPassThru();
		targetRailPoint.Deactivate();
		getNextPoint();
		StopAllCoroutines();
		yield return null;
	}
}
