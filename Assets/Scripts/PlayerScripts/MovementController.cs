﻿using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    FaceMovementDirection graphicsSync;
    [SerializeField]
    AudioManager SFXManager;

    [SerializeField]
    int forwardSpeed;
    [SerializeField]
    int maxForwardSpeed;
    [SerializeField]
    int strafeSpeed;
    [SerializeField]
    int maxStrafeSpeed;
    [SerializeField]
    int jumpVelocity;

    [SerializeField]
    AudioClip run_SFX;
    [SerializeField]
    AudioClip jump_SFX;

    Vector3 forwardDirection;
    bool grounded = true;

    [SerializeField]
    Rigidbody playerRigidbody;

    bool forwardPressed = false;
    bool strafePressed = false;
    bool jumpPressed = false;
    // Use this for initialization

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            forwardPressed = true;
        }
        else
        {
            forwardPressed = false;
        }
        if(Input.GetAxis("Horizontal") != 0)
        {
            strafePressed = true;
        }
        else
        {
            strafePressed = false;
        }
        if(Input.GetAxis("Jump") != 0)
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }
    }

    void FixedUpdate()
    {
        if (forwardPressed)
        {
            MoveForward(Input.GetAxis("Vertical"));
        }
        if (strafePressed)
        {
            Strafe(Input.GetAxis("Horizontal"));
        }
        if (jumpPressed && grounded)
        {
            Jump();
        }
        if(Physics.Raycast(playerRigidbody.transform.position, Vector3.down, .7f))
        {
            grounded = true;
            
        }
        else
        {
            grounded = false;
        }
    }

    void MoveForward(float v)
    {
        forwardDirection = targetTransform.TransformDirection(Vector3.forward);
        forwardDirection.y = 0;
        if (!(playerRigidbody.velocity.magnitude > maxForwardSpeed))
        {

            playerRigidbody.AddForce(forwardDirection * (v * forwardSpeed));
        }
        graphicsSync.SetMovementDirection(transform.InverseTransformDirection(forwardDirection));
        if (grounded)
        {
            SFXManager.PlaySoundEffect(run_SFX);
        }
    }
    void Strafe(float h)
    {
        forwardDirection = targetTransform.TransformDirection(Vector3.forward);
        forwardDirection.y = 0;
        Vector3 rightDirection = targetTransform.TransformDirection(Vector3.right);
        rightDirection.y = 0;
        if (!(playerRigidbody.velocity.magnitude > maxStrafeSpeed))
        {
            playerRigidbody.AddForce(rightDirection * (h * strafeSpeed));
        }
        graphicsSync.SetMovementDirection(transform.InverseTransformDirection(forwardDirection));
        if (grounded)
        {
            SFXManager.PlaySoundEffect(run_SFX);
        }
    }
    void Jump()
    {
        SFXManager.PlaySoundEffect(jump_SFX);
        grounded = false;
        playerRigidbody.AddForce(Vector3.up * jumpVelocity);
    }
}
