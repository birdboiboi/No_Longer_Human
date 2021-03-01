using PlayerScripts.Brain;
using UnityEngine;

namespace PlayerScripts.Legs
{
    public class Legs: MonoBehaviour
    {
        public Brain.Brain brain;

        public void Walk(Player player)
        {
            var totalMovement = brain.GetMovement();
            totalMovement = Quaternion.Euler(0, brain.eyes.cam.transform.eulerAngles.y, 0) * totalMovement;
            player.characterController.Move(totalMovement);
        }
    }
}

