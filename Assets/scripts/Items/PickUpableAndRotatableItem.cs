﻿using System;
using Events;
using PlayerScripts.Eyes;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Items
{
    
    public  class PickUpableAndRotatableItem: Item, ICanPickUp, ICanRotate
    {
        public Rigidbody rb;
        public Transform destination;
        private bool pickedUp = false;
        private bool rotating = false;
        public bool freeze = false;
        private const int RotationSpeed = 10;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void PickUp(Transform guide)
        {
            freeze = true;
            Transform transform1;
            (transform1 = rb.transform).SetParent(guide);
            pickedUp = true;
        
            rb.useGravity = false;
            rb.isKinematic = true;
            transform1.localRotation = transform.rotation;
            transform1.position = guide.position;
        }

        private void CleanUp()
        {
            freeze = false;
            EventsManager.instance.OnCameraUnlockTrigger();
            
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.transform.SetParent(null);
            pickedUp = false;
        }
        
        public void Drop()
        {
            CleanUp();
        }

        public void Rotate()
        {
            var xRotation = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime * -Mathf.Rad2Deg;
            var yRotation = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime  * Mathf.Rad2Deg;

            transform.Rotate(Vector3.up, xRotation, Space.World);
            transform.Rotate(Vector3.right, yRotation, Space.World);
        }

        void OnMouseDown()
        {
            PickUp(destination);
        }

        void OnMouseUp()
        {
            Drop();
        }

        public bool StartRotating()
        {
            EventsManager.instance.OnCameraLockTrigger();
            Rotate();
            return true;
        }

        public bool StopRotating()
        {
            EventsManager.instance.OnCameraUnlockTrigger();
            return false;
        }
        
        void Update()
        {
            if (freeze)
            {
                //print(freeze + this.name);
                rotating = Input.GetKey("space") & pickedUp ? StartRotating() : StopRotating();
            }
        }
    }
}