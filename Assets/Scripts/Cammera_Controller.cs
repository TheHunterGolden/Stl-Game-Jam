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

    [SerializeField]
    private float attachSpeed = 15.0f;

    [SerializeField]
    private float maxCameraSpeed = 20.0f;

    private Vector3 moveTemp;
    private float tempDeltaX;
    private Vector2 moveSpeed = new Vector2(0.0f, 0.0f);
    private Vector2 tmpMoveSpeed = new Vector2(0.0f, 0.0f);

    [SerializeField]
    private Vector3 offset = new Vector3(5.0f, 5.0f, 0.0f);


    void Start ()
    {
        moveTemp = followObject.transform.position;
    }

    void LateUpdate()
    {
        //Input handling
        if (Input.GetButton("Right") && moveSpeed.x <= maxCameraSpeed)
        {
            if (moveSpeed.x < 0.0f)
                moveSpeed.x = 0.0f;
            moveSpeed.x += deltaSpeed;
        }
        else if (Input.GetButton("Left") && moveSpeed.x >= -maxCameraSpeed)
        {
            if (moveSpeed.x > 0.0f)
                moveSpeed.x = 0.0f;
            moveSpeed.x -= deltaSpeed;
        }
        else if (moveSpeed.x > 0.0f)
        {
            moveSpeed.x -= deltaSpeed;
        }
        else if (moveSpeed.x < 0.0f)
        {
            moveSpeed.x += deltaSpeed;
        }

        //position handling
        moveTemp = followObject.transform.position;
        if (moveSpeed.x > 5.0f)
        {
            moveTemp.x += offset.x;
            print("In");
        }

        if (moveSpeed.x < -5.0f)
        {
            moveTemp.x -= offset.x;
            print("Here");
        }
        moveTemp.y = followObject.transform.position.y;
        moveTemp.z = transform.position.z;

        //movement smoothing
        tmpMoveSpeed.x = moveSpeed.x;
        tempDeltaX = Mathf.SmoothDamp(transform.position.x, moveTemp.x, ref tmpMoveSpeed.x, smoothTime);
        moveTemp.x = tempDeltaX;

        //apply changes
        transform.position = moveTemp;
    }
	
}
