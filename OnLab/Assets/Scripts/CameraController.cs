using UnityEngine;

public class CameraController : MonoBehaviour {

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;


    public float currentX = 100.0f;
    public float currentY = 0.0f;
    public float currentZ = 100;
    public float sensivityX = 4.0f;
    public float sensivityY = 4.0f;

    private void start()
    {
        camTransform = transform;
    }

    private void Update()
    { 
            currentX += sensivityX * Input.GetAxis("Horizontal");
            currentY += sensivityY * Input.GetAxis("Vertical");
    }

    private void LateUpdate()
    {
        camTransform.position = new Vector3(currentX, currentY, currentZ);
    }
}
