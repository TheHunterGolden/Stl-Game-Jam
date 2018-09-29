using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparky_Controller : MonoBehaviour {

    public float speed = 10.0f;

    void Update()
    {
        
        float translation_x = 0.0f, translation_y = 0.0f;

        //Input handling
        if (Input.GetButton("Left"))
            translation_x = -speed;
        if (Input.GetButton("Right"))
            translation_x = speed;
        if (Input.GetButton("Up"))
            translation_y = speed;
        if (Input.GetButton("Down"))
            translation_y = -speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation_x *= Time.deltaTime;
        translation_y *= Time.deltaTime;

        transform.Translate(translation_x, 0, 0);
        transform.Translate(0, translation_y, 0);
    }
}
