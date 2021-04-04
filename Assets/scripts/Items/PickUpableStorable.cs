using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;
using Events;
using PlayerScripts.Eyes;
using UnityEngine.PlayerLoop;
using UnityEditor.Experimental.GraphView;

//using InventoryFolder;

public class PickUpableStorable : PickUpableAndRotatableItem,ICanStore
{
    public Sprite picture;
    public InventoryStruct playerBag;
    public LetterHandler lh;
    private bool openedUI = false;

    public void Store() {

        playerBag = destination.transform.GetChild(0).GetComponent<Inventory>().bag;
        playerBag.addItem(this.gameObject);
        Debug.Log(playerBag + "player bag");
        DropAndClear();
        this.gameObject.SetActive(false);
    }

    public void UnStore()
    {
        this.gameObject.transform.position = destination.transform.position;
        this.gameObject.SetActive(false);
        playerBag.removeItem(this.gameObject);
        playerBag = null;
        Drop();


    }

    void OnMouseDown()
    {
        
            Cursor.lockState = CursorLockMode.None;
            EventsManager.instance.OnCameraLockTrigger();
            lh.SendMessage("DisplayStoreDrop", this);
            PickUp(destination);
    }

    void OnMouseUp()
    {

    }

    public void DropAndClear() { 
        Cursor.lockState = CursorLockMode.Locked;
        lh.SendMessage("CloseDisplay");
        EventsManager.instance.OnCameraUnlockTrigger();
        Drop();
    }
    void Update()
    {
        if (freeze)
        {
            //print(freeze + this.name);
            //rotating = Input.GetKey("space") & pickedUp ? StartRotating() : StopRotating();
        }
    }


    public void checkIfPict()
    {
        if (picture == null)
        {
            picture = lh.defaultImage;
        }
    }
}
