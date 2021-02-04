using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    void Unlock(Door target);
    void OpenInventory();
    void PickUp(Item item);
    void Move();
}

public class Player : MonoBehaviour, IPlayer
{
    private CharacterController characterController;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.AddComponent<CharacterController>();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVerticaL);
        characterController.Move(move * Time.detaTime * playerSpeed);
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move
        }
    }

    void Unlock(Door target)
    {
        
    }

    void OpenInventory()
    {
        
    }

    void PickUp(Item item)
    {
        
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
