using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private CharacterController characterController;
    private Rigidbody rb;
    private Vector3 move;
    public float playerSpeed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.AddComponent<CharacterController>();
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        characterController.Move(move * Time.deltaTime * playerSpeed);
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
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
