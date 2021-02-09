using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float movementX;
    float movementY;
    [SerializeField] float speed = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>();
        this.movementX = movementVector.x;
        this.movementY = movementVector.y;
    }
    
    void FixedUpdate()
    {
        var movement = new Vector3(this.movementX, 0f, this.movementY);
        rb.AddForce(movement * this.speed);
    }

}
