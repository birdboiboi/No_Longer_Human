using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryBtnManager : MonoBehaviour
{

    public Inventory bag;
    public Button[] buttons = new Button[6];
    public Dictionary<string,GameObject> ButtonMap = new Dictionary<string, GameObject>();
    
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
        for (int i = 0; i < bag.bag.listItems().Count; i++)
        {
            Debug.Log(buttons[i] + " , " + bag.bag.listItems()[i]);
            buttons[i].GetComponent<Image>().sprite = bag.bag.listItems()[i].GetComponent<PickUpableStorable>().picture;
        }
        

    }
   
    void SlotPress()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }


}
