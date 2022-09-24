using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Control player viewpoint/movement direction with the mouse

    [Header("Movement")]
    public float moveSpeed = 6f;
    public float movementMultiplier = 10f;

    float rbDrag = 6f;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }


    private void Update()
    {
        MyInput();
        ControlDrag();  
    }


    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }


    void ControlDrag()
    {
        rb.drag = rbDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }




}
