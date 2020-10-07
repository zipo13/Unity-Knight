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
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent("CharacterController2D");
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            anim.SetTrigger("Jump");
        }

        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
            anim.SetBool("Crouch", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
            anim.SetBool("Crouch", false);
        }
    }

    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
    }
}
