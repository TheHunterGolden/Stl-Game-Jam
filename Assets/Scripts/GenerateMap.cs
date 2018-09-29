using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

    [SerializeField]
    private GameObject rail;
    [SerializeField]
    private GameObject line;
    private float top;
    private float side;
	// Use this for initialization
	void Start () {
        
        top = Screen.width / 3;
        Debug.Log(top);
        side = Screen.height / 3;
        Debug.Log(side);
        setRailEdges();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void setRailEdges() {
        
        Instantiate(rail, new Vector3(top , 0), Quaternion.identity); 
            
    }
}
