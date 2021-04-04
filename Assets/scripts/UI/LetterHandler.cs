using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterHandler : MonoBehaviour
{
    
    public Canvas can;
    public GameObject[] lettersUI;
    public GameObject inventoryUI;
    public GameObject StoreDropUI;

    public Inventory invent;

    private GameObject displayObject;
    public Image defaultImage;

    //public bool viewThis = false;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void DisplayLetter(int i)
    {
        displayObject = Instantiate(lettersUI[i], can.transform);
        displayObject.transform.SetParent(transform.parent);

    }
    void CloseDisplay()
    {
        Destroy(displayObject);
    }

    void DisplayInventory()
    {
        displayObject = Instantiate(inventoryUI, can.transform);
        displayObject.transform.SetParent(transform.parent);
    }


    void DisplayStoreDrop(PickUpableStorable objectToStore)
    {
        Debug.Log(objectToStore);
        displayObject = Instantiate(StoreDropUI, can.transform);
        StoreDropDecision comp = displayObject.GetComponent<StoreDropDecision>();
        comp.PUS = objectToStore;
        displayObject.transform.SetParent(transform.parent);
    }
}
