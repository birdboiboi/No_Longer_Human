using UnityEngine;
using UnityEngine.XR;

namespace Events
{
    public class CameraTrigger: MonoBehaviour
    {
        private void OnLockTrigger(Eyes eyes)
        {
            Cursor.lockState = CursorLockMode.None;
            EventsManager.instance.OnCameraLockTrigger();
        }

        private void OnUnlockTrigger(Eyes eyes)
        {
            Cursor.lockState = CursorLockMode.Locked;
            EventsManager.instance.OnCameraUnlockTrigger();
        }
    }
}