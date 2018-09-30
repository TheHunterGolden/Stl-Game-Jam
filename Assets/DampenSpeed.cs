using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampenSpeed : MonoBehaviour {

    public GameObject sparky;
    public float scale;
    public float counter = 1;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        counter =- Time.deltaTime;
        if (counter > 0) {
            counter = 1;
            subtractSpeed(scale);
        }
    }

    public void subtractSpeed(float s)
    {
    
        sparky.GetComponent<Ball>().setSpeed(sparky.GetComponent<Ball>().getSpeed() - s);
    }

    public void resetSpeed() {

    }
}
