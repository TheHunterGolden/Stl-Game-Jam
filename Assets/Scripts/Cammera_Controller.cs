using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cammera_Controller : MonoBehaviour {

    private Vector2 velocity;

    public GameObject player;
    public float smoothTimeY;
    public float smoothTimeX;

    void LateUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeX);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
	
}
