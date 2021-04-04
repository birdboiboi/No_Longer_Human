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
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!UIOpened)
            {
                
                lh.SendMessage("DisplayInventory");
            }
            else
            {
                
                lh.SendMessage("CloseDisplay");
            }
            UIOpened = !UIOpened;
        }
    }
    

}
