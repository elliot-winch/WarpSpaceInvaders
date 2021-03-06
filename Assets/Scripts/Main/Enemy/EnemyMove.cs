﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float linearSpeed = 0.1f;
    public float anglurSpeed = 5f;
    public float radiusIncreaseDistance = 1f;

    private float pathAngle = 360;
    private bool rotating = false;

    private void Update()
    {

        if(pathAngle >= 360)
        {
            StartCoroutine(IncreaseRadius());

            pathAngle = 0;
        } else if (rotating)
        {
            float angle = anglurSpeed * Time.deltaTime;
            transform.RotateAround(Vector2.zero, Vector3.forward, angle);

            pathAngle += angle;
        }
    }

    IEnumerator IncreaseRadius()
    {
        rotating = false;

        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = linearSpeed * -transform.up;

        yield return new WaitForSeconds(radiusIncreaseDistance / linearSpeed);

        rb2d.velocity = Vector2.zero;

        rotating = true;
    }
}
