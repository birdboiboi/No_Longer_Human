using System.Collections;
using System.Collections.Generic;
using System;
using PlayerScripts.Brain;
using UnityEngine;


namespace PlayerScripts
{
    public class Player : MonoBehaviour, IPlayer
    { 
        public CharacterController characterController; 
        public Brain.Brain brain;
    
        // Start is called before the first frame update
        void Start()
        {
            characterController = gameObject.GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            brain.ExecuteUpdateGameLoop();
        }

        void FixedUpdate()
        {
            brain.ExecuteFixedUpdateGameLoop();
        }
    }

}
