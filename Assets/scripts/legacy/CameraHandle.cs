﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour
{
    public float sensitiveity = 100;
    public Transform body;
    public float distHold;
    private float xRot = 0;
    //private bool isHold;
    public GameObject item = null;
    private Camera cam;
    public float rotateSpeed = 1f;
    public Shader glow;
    public Shader normalShader;
    public GameObject tempItem;

    private bool isRotate;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        float yaw = Input.GetAxis("Mouse Y") * sensitiveity * Time.deltaTime;
        float pitch = Input.GetAxis("Mouse X") * sensitiveity * Time.deltaTime;
        xRot -= yaw;

        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        body.Rotate(pitch * Vector3.up);
        int layerMask = 1 << 8;

        RaycastHit hit;
        if (item == null)
        {
            isRotate = false;

            Vector3 CameraCenter = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, cam.nearClipPlane));
            if (Physics.Raycast(CameraCenter, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {

                Debug.DrawRay(CameraCenter, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                tempItem = hit.collider.gameObject;
                //ormalShader = tempItem.GetComponent<Renderer>().material.shader;
                tempItem.GetComponent<Renderer>().material.shader = glow;

                if (Input.GetButtonUp("Fire1"))
                {

                    //with(item)
                    //{
                    item = tempItem;
                    item.GetComponent<Renderer>().material.shader = glow;
                    item.transform.SetParent(this.gameObject.transform);
                    //item.GetComponent<Rigidbody>().isKinematic = false;
                    item.GetComponent<Rigidbody>().useGravity = false;
                    item.GetComponent<Collider>().enabled = false;
                    item.transform.rotation = transform.rotation;
                    item.transform.position = transform.position + cam.transform.TransformDirection(Vector3.forward) * distHold;
                    //item.GetComponent<Renderer>().material.shader = glow;
                    //}


                }

            }
            else
            {
                Debug.DrawRay(CameraCenter, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);

                if (tempItem != null)
                {
                    //Debug.Log("switch shades back");
                    tempItem.GetComponent<Renderer>().material.shader = normalShader;
                    tempItem = null;
                }
            }
        }
        else
        {

            if (Input.GetButtonUp("Fire1"))
            {
                //using (item)
                //{
                item.GetComponent<Collider>().enabled = true;
                //item.GetComponent<Rigidbody>().isKinematic = true;
                item.GetComponent<Rigidbody>().useGravity = true;
                //item.GetComponent<Renderer>().material.shader = normalShader;
                item.transform.parent = null;

                //}

                item = null;
            }

            if (Input.GetButtonUp("Fire2"))
            {
                isRotate = !isRotate;
            }
            if (isRotate)
            {
                item.transform.Rotate(0, rotateSpeed, 0);
            }
        }
    }
}
