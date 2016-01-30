﻿using UnityEngine;
using System.Collections;

public class FaceMovementDirection : MonoBehaviour {

    Vector3 movementDirection = Vector3.forward;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementDirection != Vector3.zero)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementDirection), .5f);
    }
    public void SetMovementDirection(Vector3 vel)
    {
        movementDirection = vel;
        //Debug.Log(movementDirection);
    }
}