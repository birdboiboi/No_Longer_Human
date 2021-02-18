using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



public class Player : MonoBehaviour, IPlayer
{ 
    private CharacterController characterController; 
    private Rigidbody rb;
    private Vector3 move;
    private bool groundedPlayer;
    [SerializeField] Brain brain;
    [SerializeField] public Eyes eyes;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    public void Move()
    {
        var totalMovement = brain.GetMovement();
        totalMovement = Quaternion.Euler(0, eyes.cam.transform.eulerAngles.y, 0) * totalMovement;
        characterController.Move(totalMovement);
    }

    public void Unlock(Door target)
    {
        target.Unlock();
    }

    public void OpenInventory()
    {
        return;
    }

    public void PickUp(Item item)
    {
        return;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }
}
