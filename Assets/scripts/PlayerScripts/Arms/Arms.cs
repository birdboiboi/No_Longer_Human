using Items;
using TMPro;
using UnityEngine;

namespace PlayerScripts.Arms
{
    public class Arms: MonoBehaviour, IArms
    {

        public void PickUp(PickUpableItem item, Transform destination)
        {
            item.PickUp(destination);
        }

        public void Unlock(Door target)
        {
            target.Unlock();
        }

        public void Lock(Door target)
        {
            target.Lock();
        }

        public void OpenInventory()
        {
        
        }

    }
}

