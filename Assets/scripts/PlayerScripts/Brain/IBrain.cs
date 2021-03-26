using UnityEngine;

namespace PlayerScripts.Brain
{
    public interface IBrain
    {
        public (float x, float y) GetMouse();
        public Vector3 GetMovement();
    }

}
