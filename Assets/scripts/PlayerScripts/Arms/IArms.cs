
using Items;
using UnityEngine;

namespace PlayerScripts.Arms
{
    public interface IArms
    {
        void Unlock(Door target);
        void Lock(Door target);
        void OpenInventory();
        void PickUp(PickUpableAndRotatableItem item, Transform destination);
    }
}
