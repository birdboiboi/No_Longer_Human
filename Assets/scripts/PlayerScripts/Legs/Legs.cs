using System.Runtime.CompilerServices;
using PlayerScripts.Brain;
using UnityEngine;

namespace PlayerScripts.Legs
{
    public class Legs: MonoBehaviour
    {
        public Brain.Brain brain;

        public void Walk(Player player, int modifier = 1)
        {
            var totalMovement = brain.GetMovement();
            totalMovement = Quaternion.Euler(
                0, brain.eyes.cam.transform.eulerAngles.y, 0) * totalMovement * modifier;
            player.characterController.Move(totalMovement);
        }

        public void Run(Player player)
        {
            Walk(player, 2);
        }

        public void Move(Player player)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run(player);
            }
            else
            {
                Walk(player);
            }
        }
    }
}

