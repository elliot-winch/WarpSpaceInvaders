using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public KeyCode clockwise;       
    public KeyCode antiClockwise;
    public float rotationSpeed;             

	
	void Update () {

        if (Input.GetKey(clockwise))
        {
            transform.RotateAround(Vector2.zero, Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(antiClockwise))
        {
            transform.RotateAround(Vector2.zero, Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
    }
}
