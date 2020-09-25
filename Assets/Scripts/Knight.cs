using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float runSpeed = 2f;
    public CharacterController2D characterController;
    private float horizontalMove = 0f;
    private bool isJumping = false;
    private bool isCrouching = false;

    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent("CharacterController2D");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            print("left key was pressed");

            //transform.
            //transform2 += Vector2.left * Time.deltaTime * speed;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }
    }

    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
    }
}
