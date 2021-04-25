using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    private bool isOpen = false;
    public Animator doorAnim;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocked)
        {
            Lock();
        }
        else
        {
            Unlock();
        }
        col = GetComponent<Collider>();
    }

    public void Unlock()
    {
        isLocked = false;
        doorAnim.SetBool("Is_Lock", isLocked);
    }

    public void Lock()
    {
        isLocked = true;
        doorAnim.SetBool("Is_Lock", isLocked);
        

    }

    public void Open() { 

        doorAnim.SetTrigger("Open");
        isOpen = !isOpen;
        col.isTrigger = false;


    }
    public void Close()
    {

        doorAnim.SetTrigger("Close");
        isOpen = !isOpen;
        col.isTrigger = true;

    }

    void OnMouseDown()
    {

        if (isOpen) {
            Close();
        }
        else
        {
            Open();
        }
    }

}
