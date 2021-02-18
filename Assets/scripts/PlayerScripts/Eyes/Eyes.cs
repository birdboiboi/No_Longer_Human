using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] public Brain brain;
    [SerializeField] public Camera cam;
    private Player player;
    public Transform playerBody;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private float minimumX = -60f;
    private float maximumX = 60f;
    private float minimumY = -360f;
    private float maximumY = 360f;

    private class Hit
    {
        private RaycastHit hit;
        private bool hasHit;
    }

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        brain = new Brain();
        cam = GetComponent<Camera>();
        
    }
    
    public (bool hasHit, RaycastHit hit) CurrentFocus()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hasHit = Physics.Raycast(ray, out var hit);
        return (hasHit, hit);
    }
    
    private (float x, float y) GetRotations()
    {
        var (xAxis, yAxis) = brain.GetMouse(); 
        xRotation += yAxis;
        yRotation += xAxis;

        return ClampRotations(xRotation, yRotation);
    }

    private (float x, float y) ClampRotations(float x, float y)
    {
        xRotation = Mathf.Clamp(x, minimumX, maximumX);
        return (xRotation, y);
    }
    
    void Update()
    {
        (float x, float y) positions = GetRotations();

        transform.localEulerAngles = new Vector3(0, positions.y, 0);
        cam.transform.localEulerAngles = new Vector3(-positions.x, positions.y, 0);
    }
}
