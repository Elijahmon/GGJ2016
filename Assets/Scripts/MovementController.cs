using UnityEngine;
using System.Collections;

public class MovementController: MonoBehaviour
{ 

    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    FaceMovementDirection graphicsSync;

    [SerializeField]
    int forwardSpeed;
    [SerializeField]
    int maxForwardSpeed;
    [SerializeField]
    int strafeSpeed;
    [SerializeField]
    int maxStrafeSpeed;

    Vector3 forwardDirection;

     [SerializeField]
     Rigidbody playerRigidbody;


        // Use this for initialization

    void FixedUpdate()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            MoveForward(Input.GetAxis("Vertical"));
        }
        if(Input.GetAxis("Horizontal") != 0)
        {
            Strafe(Input.GetAxis("Horizontal"));
        }
    }
    
        void MoveForward(float v)
        {
            Vector3 forwardDirection = targetTransform.TransformDirection(Vector3.forward);
            forwardDirection.y = 0;
            if (!(playerRigidbody.velocity.magnitude > maxForwardSpeed))
            {
                    
                playerRigidbody.AddForce(forwardDirection * (v * forwardSpeed));
            }
            graphicsSync.SetMovementDirection(transform.InverseTransformDirection(playerRigidbody.velocity));
        }
        void Strafe(float h)
        {
            Vector3 rightDirection = targetTransform.TransformDirection(Vector3.right);
            rightDirection.y = 0;
            if (!(playerRigidbody.velocity.magnitude > maxStrafeSpeed))
            {
                playerRigidbody.AddForce(rightDirection * (h * strafeSpeed));
            }
            graphicsSync.SetMovementDirection(transform.InverseTransformDirection(playerRigidbody.velocity));
        }
}
