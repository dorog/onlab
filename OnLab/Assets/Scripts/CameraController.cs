using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;
    private bool follow = true;
    public float rotationSpeed = 0.5f;

    //private Camera cam;

    public float distance = 10.0f; // distance beetween target and camera
    public float currentX = 100.0f;
    public float currentY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

    private void start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            follow = !follow;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            distance *= 1.05f;

        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance /= 1.05f;
        }

        if (Input.GetMouseButton(1))
        {
            currentX += sensivityX * Input.GetAxis("Mouse X");
            currentY -= sensivityY * Input.GetAxis("Mouse Y");
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        /*if (follow)
        {
            float rot = Input.GetAxis("Horizontal");
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(rot*rotationSpeed, 0, 0);
            camTransform.position = lookAt.position + rotation * dir;
        }*/

    }

    private void LateUpdate()
    {
        float rot = 0;
        if (follow)
        {
            rot = Input.GetAxis("Horizontal") * rotationSpeed;
            /*Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, rot, 0);
            camTransform.position = lookAt.position + rotation * dir;

            camTransform.LookAt(lookAt.position);*/
        }
        /*else
        {*/
        currentX += rot;
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        camTransform.position = lookAt.position + rotation * dir;

        camTransform.LookAt(lookAt.position);
        //}

    }
}
