using System;
using PlayerScripts.Eyes;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Items
{
    public class PickUpableItem: Item, CanPickUp
    {
        private Rigidbody rb;
        public Transform destination;
        public Eyes eyes;
        private bool pickedUp = false;
        private bool rotating = false;
        private const int RotationSpeed = 1;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void PickUp(Transform guide)
        {
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
            rb.useGravity = true;
            rb.isKinematic = false;
            eyes.locked = false;
            rb.transform.SetParent(null);
            pickedUp = false;
        }
        
        public void Drop()
        {
            CleanUp();
        }

        public void Rotate()
        {
            var xRotation = Input.GetAxis("Mouse X") * RotationSpeed * -Mathf.Rad2Deg;
            var yRotation = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Rad2Deg;

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

        bool OnSpaceDown()
        {
            Cursor.lockState = CursorLockMode.None;
            eyes.locked = true;
            return true;
        }

        bool OnSpaceUp()
        {
            Cursor.lockState = CursorLockMode.Locked;
            eyes.locked = false;
            return false;
        }

        void Update()
        {
            rotating = Input.GetKey("space") ? OnSpaceDown() : OnSpaceUp();
            if (pickedUp & rotating)
            {
                Rotate();
            }
        }
    }
}