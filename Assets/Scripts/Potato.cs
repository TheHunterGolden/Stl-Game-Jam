﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(gameObject.transform.localPosition, Random.Range(10, 120) * Time.deltaTime);	
	}
}
