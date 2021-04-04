using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class InventoryStruct
{
    public List<GameObject> items = new List<GameObject>();
    public int max;
    public int size;

    public InventoryStruct(int size)
    {
        max = size;
        
    }
    

    public void addItem(GameObject item)
    {
        
        items.Add(item);
    }

    public void removeItem(GameObject item)
    {
        items.Remove(item);
    }

    public GameObject getItem(int idx)
    {
        return items[idx];
    }

    public List<GameObject> listItems()
    {
        return items;
    }

    string ToString()
    {
        string outStr = "in this are";
        foreach (GameObject item in listItems())
        {
            outStr += item.name + ",";
        }
        return outStr;
    }
}
