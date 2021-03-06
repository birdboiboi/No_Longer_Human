﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharMove : MonoBehaviour
{
    //Current charachter's velocity, used for gravity
    private Vector3 playerVelocity;
    private bool groundedPlayer;


    //Set Up
    public CharacterController controller;
    public MonsterTrickle monstScript;
    //Properties
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public bool isSeen;
    public float numReflection; //external mirror count
    public Vector3 offsetSpawn = new Vector3(1, 0, 0);
    public AudioSource layerTheme;
    public Animator anim;
    public Vector3 move;
    public AudioClip walk;

    public GameObject thisMirror; // start mirror

    public GameObject lastMirror;

   private bool isWalk= false;
   public float nextTime = 0;
   public float timeOffset = 10;



    // Start is called before the first frame update
    void Start()
    {
        //controller = gameObject.GetComponent<CharacterController>();
        playAudio();
    }

    // Update is called once per frame
    void Update()
    {

        //check if atleast one external mirror is is looking and update global boolean status
        if (numReflection > 0)
        {
            isSeen = true;
        }
        else
        {
            isSeen = false;
        }

        //use inbuilt function of Unity CharachterController script in order to check if the bottom f the mesh is touching a surface
        groundedPlayer = controller.isGrounded;


        //make sure the player loses momentum when the player touches the ground and isnt moving in the y direction
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //get Unity's "W:S" keys as "Vertical"  and "A:D" keys as "Horizontal" 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //Accelerate if airborn for gravity effect
        playerVelocity.y += gravityValue * Time.deltaTime;

        //Update one Vector3 of all movement with 3 vectors of x,y,z
        move = x * Vector3.right + z * Vector3.forward + playerVelocity;

        //get directional vector
        move = transform.TransformDirection(move);
        //Debug.Log(move);


        float currTime = Time.time;

        if (move.x != 0 && move.z != 0 )
        {
            //makeshift timer to delay when the walk sound is played...not sure if this works
            if (nextTime < currTime)
            {
                anim.Play("walk");
                //@BJ SOUND PROBLEM HERE 
                layerTheme.PlayOneShot(walk);
                nextTime = currTime + timeOffset;
            }
           // Debug.Log("walk");
        }
        else 
        {
            anim.Play("idle");
            nextTime = 0;
           // Debug.Log("idle");
        }
        //apply actual movement normalized by the change in time scaled to the inputted player speed
        controller.Move(move * Time.deltaTime * playerSpeed);


        //exit game key control @SYDNEY Refrence this to double the speed with SHIFT!!!
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("main_menu");
            Debug.Log("close");
        }

    }

    public void playAudio()
    {
        //kind of a useless method.... consider deleting if  the player uses "on awawke" check box of audio source
       layerTheme.Play();
    }

    public void ResetThismonster()
    {
        Debug.Log("main monster reset");

        //resets this player's monster's reset function
        monstScript.reset();
    }
}