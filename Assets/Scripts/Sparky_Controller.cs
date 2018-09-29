using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparky_Controller : MonoBehaviour {

    public float speed = 10.0f;

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation_y = Input.GetAxis("Vertical") * speed;
        float translation_x = Input.GetAxis("Horizontal") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation_x *= Time.deltaTime;
        translation_y *= Time.deltaTime;

        transform.Translate(translation_x, 0, 0);

        // Rotate around our y-axis
        transform.Translate(0, translation_y, 0);
    }
}
