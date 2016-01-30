using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    Transform cameraTransform;
    [SerializeField]
    float xSensitivity;
    [SerializeField]
    float ySensitivity;

    [SerializeField]
    float yLimit;



    void Awake()
    {
    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            RotateCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
    }

    void RotateCamera(float x, float y)
    {
        cameraTransform.RotateAround(targetTransform.position, Vector3.up, x * xSensitivity);
        cameraTransform.RotateAround(targetTransform.position, Vector3.right, -y * ySensitivity);
        cameraTransform.LookAt(targetTransform);
    }
}
