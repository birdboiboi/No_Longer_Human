using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private float minimumX = -60f;
    private float maximumX = 60f;
    private float minimumY = -360f;
    private float maximumY = 360f;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private (float x, float y) GetRotations()
    {
        xRotation += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        return ClampRotations(xRotation, yRotation);
    }

    private (float x, float y) ClampRotations(float x, float y)
    {
        xRotation = Mathf.Clamp(x, minimumX, maximumX);
        yRotation = Mathf.Clamp(y, minimumY, maximumY);
        return (xRotation, yRotation);
    }

    // Update is called once per frame
    void Update()
    {
        (float x, float y) positions = GetRotations();

        transform.localEulerAngles = new Vector3(0, positions.y, 0);
        cam.transform.localEulerAngles = new Vector3(-positions.x, positions.y, 0);
    }
}
