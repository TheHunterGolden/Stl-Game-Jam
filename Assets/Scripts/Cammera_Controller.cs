using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cammera_Controller : MonoBehaviour {

    [SerializeField]
    private Transform followObject;

    private Vector3 moveTemp;

    [SerializeField]
    private Vector3 offset = new Vector3(5.0f, 0.0f, 0.0f);

    void Start ()
    {
        moveTemp = followObject.transform.position;
    }

    void LateUpdate()
    {
        moveTemp = followObject.transform.position;
        moveTemp.x += offset.x;
        moveTemp.y = offset.y;
        moveTemp.z = transform.position.z;
        transform.position = moveTemp;

    }
	
}
