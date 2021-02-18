using UnityEngine;

public interface IBrain
{
    public (float x, float y) GetMouse();
    public Vector3 GetMovement();
}
