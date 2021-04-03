using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;


public class PickUpableMessage : PickUpableAndRotatableItem
{
    public int letterIdx; 
    public LetterHandler lh;

    void OnMouseDown()
    {
        this.rb.isKinematic = true;
        //transform.LookAt(destination.transform.parent);
        PickUp(destination);
        transform.Rotate(90, 0, 0);
        lh.SendMessage("Display", letterIdx);
    }

    void OnMouseUp()
    {
        lh.SendMessage("CloseDisplay");
        Drop();
    }
}
