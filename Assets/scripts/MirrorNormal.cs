using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorNormal : MirrorDI
{

    public float flipNum = 180;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void   camLookAt(RaycastHit rayCastHitPos, GameObject looker)
    {
        Vector3 dirVector = looker.transform.position - rayCastHitPos.point;

        //cam.transform.position = looker.transform.position + Vector3.forward * rayCastHitPos.point.z;
        
        //Vector3 newLookPos = newLookPosition(rayCastHitPos, looker.transform.position);
        Vector3 norm = this.transform.forward;
        Vector3 newLookPos = newLookPosition(dirVector, norm);


        float projectionMag = dirVector.magnitude * Mathf.Cos(newLookPos.y);
        Vector3 scaleDirVect = (projectionMag * dirVector);
        scaleDirVect = scaleDirVect.normalized;
        newLookPos.x = 0; //keep height same ( phi = 0)
        Quaternion thetaRotation = Quaternion.Euler(newLookPos);

        Vector3 newCamPosition = project(dirVector, norm);
        cam.transform.position = looker.transform.position + newCamPosition;


        Debug.DrawRay(looker.transform.position ,  newCamPosition, Color.blue);


        //Debug.Log("newLook Pos + 180" + newLookPos.y + 180 + "newLook Pos " + newLookPos.y);
        Debug.Log ((((((transform.rotation.eulerAngles.y) * Mathf.Deg2Rad) % (2*Mathf.PI)) % 2) * 180 + (1 - (((transform.rotation.eulerAngles.y) * Mathf.Deg2Rad) % (2 * Mathf.PI)) % 2) * 90));
        //cam.transform.eulerAngles = newLookPos - transform.rotation.eulerAngles+ Vector3.up * flipNum + Vector3.forward * 180;//
        cam.transform.eulerAngles = -  Vector3.Scale( looker.transform.eulerAngles,new Vector3(-1,1,-1)) - transform.rotation.eulerAngles + Vector3.up * flipNum + Vector3.forward * 180;

        Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) *1000, Color.yellow);
        Debug.DrawRay(looker.transform.position, rayCastHitPos.point, Color.red);
        Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);

        Debug.DrawRay(newCamPosition, -rayCastHitPos.transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);

    }
}
