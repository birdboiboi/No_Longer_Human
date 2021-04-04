using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryBtnManager : MonoBehaviour
{

    public Inventory bag;
    public Button[] buttons = new Button[6];
    public Sprite defaultImage;
    
    void Start()
    {

        foreach (Button btn in buttons) {
            btn.onClick.AddListener(SlotPress);
        }

        Populate();


    }
    void Populate()
    {
        //my bad for bag.bag
        
        Debug.Log(bag.bag.listItems().Count);
        for (int i = 0; i < bag.listItems().Count; i++)
        {
            Debug.Log(buttons[i] + " , " + bag.bag.listItems()[i]);
            buttons[i].GetComponent<Image>().sprite = bag.bag.listItems()[i].GetComponent<PickUpableStorable>().picture;
            
        }
        

    }
   
    void SlotPress()
    {
        try
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            //would like to do dictionary but I wont
            //Debug.Log();
            int idx = System.Int32.Parse(EventSystem.current.currentSelectedGameObject.name.Split(char.Parse(" "))[1]);
            Debug.Log(idx);
            bag.DropItem(idx - 1);
            buttons[idx - 1].GetComponent<Image>().sprite = defaultImage;
            Populate();
        }
        catch
        {

        }


    }


}
