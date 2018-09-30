using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMap : MonoBehaviour {

    [SerializeField]
    private GameObject rail;
    [SerializeField]
    private GameObject line;
    [SerializeField]
    private Canvas canvas;
    private RectTransform rect;

    private float top;
    private float side;
	// Use this for initialization
	void Start () {
 
        rect = canvas.GetComponent<RectTransform>();
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
        
        Instantiate(rail, new Vector3(rail.transform.position.x , rail.transform.position.y, rail.transform.position.z), Quaternion.identity ); 
            
    }
}
