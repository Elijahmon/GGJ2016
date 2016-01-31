using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform; 
    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    float yMinLimit;
    [SerializeField]
    float yMaxLimit;
    [SerializeField]
    LayerMask camBlockingLayer;
    private float x = 0.0f;
    private float y = 0.0f;

    [SerializeField]
    Vector2 speed = new Vector2(135f, 135f);
    [SerializeField]
    Vector2 maxSpeed = new Vector2(100f, 100f);

    Vector3 normalDirection = new Vector3(-1f, 0, 0);
    [SerializeField]
    float minDistance;
    [SerializeField]
    float maxDistance;

    float minHeight = .1f;
    float maxHeight = .2f;

    float targetDistance;
    float targetHeight;

    Vector3 camDirection;
    Vector3 camPosition;
    Quaternion rotation;
    void Awake()
    {
        //Cursor.visible = false;

        targetTransform.parent = null;
        Vector3 angles = cameraTransform.eulerAngles;
        x = angles.y;
        y = angles.x;
        
        camPosition = playerTransform.position + new Vector3(0, .1f, 0);
        
    }

    void Update()
    {
        GetInput();
        RotateCamera();
    }

    void RotateCamera()
    {
        camDirection = (normalDirection.x * targetTransform.forward) + (normalDirection.z * targetTransform.right);
        camDirection = camDirection.normalized;
        camPosition = playerTransform.position + new Vector3(0, .1f, 0);
        targetHeight = .3f;
        targetDistance = maxDistance;
        RaycastHit hit;
        if(Physics.Raycast(camPosition, camDirection, out hit, targetDistance + 0.2f, camBlockingLayer))
        {
            float t = hit.distance - 0.1f;
            t -= minDistance;
            t /= (targetDistance - minDistance);
            targetHeight = Mathf.Lerp(maxHeight, targetHeight, Mathf.Clamp(t, 0f, 1f));
            camPosition = playerTransform.position + new Vector3(0, targetHeight, 0);

            targetDistance = Mathf.Clamp((hit.distance - 0.1f), minDistance, maxDistance);
        }
        Vector3 lookPoint = camPosition;
        lookPoint += (targetTransform.right * Vector3.Dot((camDirection * targetDistance), targetTransform.right));
        cameraTransform.position = camPosition + (camDirection * targetDistance);
        cameraTransform.LookAt(lookPoint);
        targetTransform.position = camPosition;
        targetTransform.rotation = Quaternion.Euler(y, x, 0);
    }
    void GetInput()
    {
        x += Mathf.Clamp(Input.GetAxis("Mouse X") * speed.x, -maxSpeed.x, maxSpeed.x) * Time.deltaTime;
        y -= Mathf.Clamp(Input.GetAxis("Mouse Y") * speed.y, -maxSpeed.y, maxSpeed.y) * Time.deltaTime;
        y = ClampAngle(y, yMinLimit, yMaxLimit);
    }
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
