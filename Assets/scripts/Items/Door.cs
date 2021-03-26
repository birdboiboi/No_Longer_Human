using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isLocked = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Unlock()
    {
        isLocked = false;
    }

    public void Lock()
    {
        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
