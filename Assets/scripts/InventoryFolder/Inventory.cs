using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Events;


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
                //Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                EventsManager.instance.OnCameraLockTrigger();
                lh.SendMessage("DisplayInventory");
                
            }
            else
            {
                //Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                EventsManager.instance.OnCameraUnlockTrigger();
                lh.SendMessage("CloseDisplay");
            }
            UIOpened = !UIOpened;
        }
    }
    public List<GameObject> listItems()
    {
        return bag.listItems();
    }

    public void DropItem(int idx)
    {
        bag.getItem(idx).GetComponent<PickUpableStorable>().UnStore();
        //lh.SendMessage("DisplayInventory");
    }

}
