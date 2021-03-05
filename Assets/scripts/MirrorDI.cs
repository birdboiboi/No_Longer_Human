using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  MirrorDI : MonoBehaviour
{

    public GameObject cam;
    public RenderTexture thisRendText;
    public House thisHouse; 
    //public bool isTeleport;

    //returns this gameobject to speed up process for external class...provides external class "this" functonality
    public GameObject getGameObject() {
        return this.gameObject;
    }

    //assigns camera to position(on mirror) and angles the camera accross the angle of incident from the looker
    public abstract void camLookAt(RaycastHit rayCastHitPos, GameObject looker);

    // allows external class to get room connection
    public House getThisRoom()
    {
        return thisHouse;
    }

    

    public static Vector3 newLookPosition(Vector3 u, Vector3 v)
    {
        Vector3 dirVect = Vector3.Normalize(u-v);
        float theta= Mathf.Atan((Mathf.Sqrt(Mathf.Pow(dirVect.x, 2) + Mathf.Pow(dirVect.y, 2))/(dirVect.z)));
        float phi = Mathf.Atan(dirVect.y + .0000000001f / dirVect.x);


        float flippyTheta = theta * (Mathf.Max(dirVect.x, 0) / (dirVect.x + .00001f)) * -1 + theta * (Mathf.Min(dirVect.x, 0) / (dirVect.x + .00001f));

        //flippyTheta = theta * Mathf.Max(dirVect.x * dirVect.z, 0)/(dirVect.x * dirVect.z) * -1 + theta * Mathf.Min(dirVect.x * dirVect.z, 0)/(dirVect.x * dirVect.z);
        Debug.Log(theta);
        Debug.Log("theta " +flippyTheta + " dirVect " + dirVect);
        return new Vector3(phi, flippyTheta, 0)  * Mathf.Rad2Deg ;
        //return new Vector3(10, 10, 1);


    }
}
