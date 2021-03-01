using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerScripts.Brain;

namespace PlayerScripts.Eyes
{
    public class Eyes : MonoBehaviour
    {
        public Brain.Brain brain;
        public Camera cam;
        public bool locked = false;
        
        private float xRotation;
        private float yRotation;
        private float minimumX = -60f;
        private float maximumX = 60f;
        
    
    
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            cam = GetComponent<Camera>();
            
        }
        
        public (bool hasHit, RaycastHit hit) CurrentFocus()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hasHit = Physics.Raycast(ray, out var hit);
            return (hasHit, hit);
        }
        
        public Vector3 GetCenterScreen()
        {
            return Input.mousePosition;
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
            if (locked) { return; }

            (float x, float y) positions = GetRotations();
    
            transform.localEulerAngles = new Vector3(0, positions.y, 0);
            cam.transform.localEulerAngles = new Vector3(-positions.x, positions.y, 0);
        }
    }
}

