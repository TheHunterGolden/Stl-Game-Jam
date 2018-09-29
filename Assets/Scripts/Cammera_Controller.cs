using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cammera_Controller : MonoBehaviour {

    [SerializeField]
    private Transform followObject;

    [SerializeField]
    private float deltaSpeed = 0.5f;

    [SerializeField]
    private float smoothTime = 0.25f;

    private Vector3 moveTemp;
    private float tempDeltaX;
    private float moveSpeed;

    [SerializeField]
    private Vector3 offset = new Vector3(5.0f, 0.0f, 0.0f);

    void Start ()
    {
        moveTemp = followObject.transform.position;
    }

    void LateUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0.0)
        {
            moveSpeed += deltaSpeed;
        }
        else if (moveSpeed > 0)
        {
            moveSpeed -= deltaSpeed;
        }
        else
        {
            moveSpeed = 0.0f;
        }

        print(moveSpeed);

        moveTemp = followObject.transform.position;
        if (moveSpeed > 5.0f)
            moveTemp.x += offset.x;
        else
            moveTemp.x = moveTemp.x;
        moveTemp.y = transform.position.y;
        moveTemp.z = transform.position.z;
        tempDeltaX = Mathf.SmoothDamp(transform.position.x, moveTemp.x, ref moveSpeed, smoothTime);
        moveTemp.x = tempDeltaX;
        transform.position = moveTemp;
    }
	
}
