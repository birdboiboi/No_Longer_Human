using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class Inventory : MonoBehaviour
{
    public int bagSize = 6;
    public InventoryStruct bag;
    public LetterHandler lh;
    private bool UIOpened = false;
    //public LetterHandler lh;

    // Start is called before the first frame update
    void Start()
    {
        bag = new InventoryStruct(bagSize);

    }

   
   void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            if (!UIOpened)
            {
                UIOpened = true;
                lh.SendMessage("DisplayInventory");
            }
            else
            {
                UIOpened = true;
                lh.SendMessage("CloseDisplay");
            }

        }
    }
    

}
