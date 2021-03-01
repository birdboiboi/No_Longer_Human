using UnityEngine;

namespace Items
{
    public interface CanPickUp
    {
        public void PickUp(Transform guide);
        public void Drop();
    }
}