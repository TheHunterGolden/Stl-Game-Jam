using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour {

    public Transform point_1;
    public Transform point_2;
    private LineRenderer line;

    // Use this for initialization
    void Start () {

        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.SetPosition(0, point_1.position);
        line.SetPosition(1, point_2.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
