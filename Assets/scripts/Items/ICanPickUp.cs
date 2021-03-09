using UnityEngine;

namespace Items
{
    public interface ICanPickUp
    {
        public void PickUp(Transform guide);
        public void Drop();
    }
}