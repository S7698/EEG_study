using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    /**
    [SerializeField] // for access in unity engine
    private float _speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerMovement()
    {
        // moving to left/right (see input manager)
        float horizontalInput = Input.GetAxis("Horizontal");



        // smooth: deltaTime
        // slower / fast -- multiply with 0.5f or 2f ...
        // press d: * 1 --> move to right
        // press a: * -1 --> move to left
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
    }
    **/
    
}
