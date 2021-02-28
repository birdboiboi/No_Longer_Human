using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  MirrorDI : MonoBehaviour
{

    public GameObject cam;
    public RenderTexture thisRendText;
    public Room thisRoom; 
    //public bool isTeleport;

    //returns this gameobject to speed up process for external class...provides external class "this" functonality
    public GameObject getGameObject() {
        return this;
    }

    //assigns camera to position(on mirror) and angles the camera accross the angle of incident from the looker
    public abstract void camLookAt(Vector3 rayCastHitPos, GameObject looker)
    {
        cam.position = rayCastHitPos;
        Vector3 dirVector = looker.transform.position - rayCastHitPos;
        Vector3 norm = this.transform.forward;
        float angle = vector3.angle(dirVector, norm);       
    }
    // allows external class to get room connection
    public void getThisRoom()
    {
        return thisRoom;
    }
}
