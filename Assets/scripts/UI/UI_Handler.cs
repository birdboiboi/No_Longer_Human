using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Handler : MonoBehaviour
{
    Canvas ownedCan;
    List<GameObject> openedObjects = new List<GameObject>();

    void Start()
    {
        ownedCan = this.transform.parent.transform.GetComponent<Canvas>();
    }

    void LoadUI(GameObject UI_Object)
    {
        GameObject displayObject = Instantiate(UI_Object, ownedCan.transform);
        openedObjects.Add(displayObject);
        displayObject.transform.SetParent(transform.parent);
        
    }

    void RemoveUI(GameObject UI_Object)
    {
        openedObjects.Remove(UI_Object);
        Destroy(UI_Object);
    }

    void ClearAll()
    {
        foreach(GameObject openedObj in openedObjects){
            RemoveUI(openedObj);
        }
    }
}
