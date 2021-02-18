using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brain : MonoBehaviour, IBrain
{
    
    private readonly float mouseSensitivity = 100f;
    private readonly float playerSpeed = 2.0f;

    void Start()
    {
         
    }

    public (float x, float y) GetMouse()
    {
        return (
            Input.GetAxis("Mouse X") * mouseSensitivity  * Time.deltaTime,
            Input.GetAxis("Mouse Y") * mouseSensitivity  * Time.deltaTime
            );
    }

    public Vector3 GetMovement()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        var totalMovement = playerSpeed * Time.deltaTime * movement;
        return totalMovement;
    }

    public Vector3 GetCenterScreen()
    {
        return Input.mousePosition;
    }
}