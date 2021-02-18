using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPlayer
{
    void Unlock(Door target);
    void OpenInventory();
    void PickUp(Item item);
    void Move();
}