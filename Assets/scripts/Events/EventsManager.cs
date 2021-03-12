using UnityEngine;
using System;

namespace Events
{
    public class EventsManager: MonoBehaviour
    {
        public static EventsManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(this);
            }
        }

        public event Action CameraLockTrigger;
        public event Action CameraUnlockTrigger;

        public void OnCameraLockTrigger()
        {
            CameraLockTrigger?.Invoke();
        }

        public void OnCameraUnlockTrigger()
        {
            CameraUnlockTrigger?.Invoke();
        }
    }
}