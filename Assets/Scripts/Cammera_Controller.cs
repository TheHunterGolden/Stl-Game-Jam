using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cammera_Controller : MonoBehaviour {

    [SerializeField]
    private GameObject sparky;
    
    [SerializeField]
    private Transform followObject;

    private Ball ball;
    private Vector3 ballDirections, prevBallDirections;

    [SerializeField]
    private float smoothTime = 0.25f;

    [SerializeField]
    private float offsetSpeed = 0.25f;

    private Vector3 moveTemp;
    private float tempDeltaX, tempDeltaY;
    private float cameraSpeed, tempCameraSpeed;

    [SerializeField]
    private Vector3 offset = new Vector3(5.0f, 5.0f, 0.0f);

    void Start ()
    {
        moveTemp = followObject.transform.position;
        ball = sparky.GetComponent<Ball>();
    }

    void LateUpdate()
    {
        //Input handling
        ballDirections = ball.getDir();
        cameraSpeed = ball.getSpeed();

        //position handling
        moveTemp = followObject.transform.position;
        if (ballDirections.x > 0.0)
        {
            if (cameraSpeed > offsetSpeed)
                moveTemp.x += offset.x;
        }
        else
        {
            if (cameraSpeed > offsetSpeed)
                moveTemp.x -= 2.0f*offset.x;
        }

        if (ballDirections.y > 0.0)
        {
            if (cameraSpeed > offsetSpeed)
                moveTemp.y += offset.y;
        }
        else
        {
            if (cameraSpeed > offsetSpeed)
                moveTemp.y -= offset.y;
        }
        moveTemp.z = transform.position.z;

        //print("desired position: " + moveTemp);
        //print("desired speed: " + cameraSpeed);
        //print("current Directions: " + ballDirections);


        //movement smoothing
        tempCameraSpeed = cameraSpeed;
        tempDeltaX = Mathf.SmoothDamp(transform.position.x, moveTemp.x, ref tempCameraSpeed, smoothTime);
        moveTemp.x = tempDeltaX;

        tempCameraSpeed = cameraSpeed;
        tempDeltaY = Mathf.SmoothDamp(transform.position.y, moveTemp.y, ref tempCameraSpeed, smoothTime);
        moveTemp.y = tempDeltaY;

        //apply changes
        transform.position = moveTemp;
    }
	
}
