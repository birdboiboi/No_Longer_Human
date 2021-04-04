using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;


public class StoreDropDecision : MonoBehaviour
{
    public PickUpableStorable PUS;

    public void Store()
    {
        Debug.Log("store Down");
        PUS.Store();
    }
    public void Drop()
    {
        Debug.Log("Drop Down");
        PUS.DropAndClear();
    }

}
