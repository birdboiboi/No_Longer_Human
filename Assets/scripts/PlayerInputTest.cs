using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputTest : MonoBehaviour
{
    int layerMask = 1 << 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(1 * Mathf.Sin(Time.time) * Time.deltaTime, 0, 0);
       // transform.Rotate(0,90* Mathf.Sin(Time.time) * Time.deltaTime  , 0);
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            hit.collider.gameObject.GetComponent<MirrorDI>().camLookAt(hit,this.gameObject); 
        }
    }
}
