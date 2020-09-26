using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BoxCollider2D playerCollider;
    float sizeOfY, sizeOfY_Crouch, offsetOfY, offsetOfY_Crouch, horizontal, vertical;
    float speed = 5;
    float jumpMovement = 100;
    int currentTime = 0;
    int CrouchTime = 10;
    bool jump, crouch, crouch_down, crouchActionCheck = false;
    public Animator animator;
    public Rigidbody2D rb2d;
   
    //Start
    public void Start()
    {
        playerCollider = playerCollider.GetComponent<BoxCollider2D>();
        sizeOfY = playerCollider.size.y;
        sizeOfY_Crouch = playerCollider.size.y - 0.8f;
        offsetOfY = playerCollider.offset.y;
        offsetOfY_Crouch = playerCollider.offset.y - 0.4f;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    //Update
    public void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        crouchActionCheck = Input.GetKey(KeyCode.LeftControl);

        verticalMovementAnimation(vertical);
        crouchAction(crouchActionCheck);
        animatorPlayerFun();
        transformPlayerFun();

    }

    //Vertical Movement Animation
    private void verticalMovementAnimation(float vertical)
    {
        if (vertical > 0)
        {
            jump = true;
            rb2d.AddForce(new Vector2(0f, jumpMovement), ForceMode2D.Force);
        }
        else
        {
            jump = false;
        }
    }

    //Crouch Action Animation
    void crouchAction(bool crouchActionCheck)
    {
        if (crouchActionCheck)
        {
            playerCollider.size = new Vector2(playerCollider.size.x, sizeOfY_Crouch);
            playerCollider.offset = new Vector2(playerCollider.offset.x, offsetOfY_Crouch);
            currentTime++;
            Debug.Log("Current Time:" + currentTime);
            if (currentTime >= CrouchTime)
            {
                crouch = true;
                crouch_down = true;
            }
            else
            {
                crouch = true;
                crouch_down = false;
            }
        }
        else
        {
            playerCollider.size = new Vector2(playerCollider.size.x, sizeOfY);
            playerCollider.offset = new Vector2(playerCollider.offset.x, offsetOfY);
            currentTime = 0;
            crouch = false;
            crouch_down = false;
        }
    }

    //Transform Function
    void transformPlayerFun()
    {
        //scale transform
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            animator.SetBool("isRunning", true);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("isRunning", true);
        }
        else if (horizontal == 0)
        {
            animator.SetBool("isRunning", false);
        }

        transform.localScale = scale;

        //Horizontal Position transform 
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;

        transform.position = position;

        //Vertical Position
        
            
    }

    //Animator Function
    void animatorPlayerFun()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("isJump", jump);
        animator.SetBool("isCrouch", crouch);
        animator.SetBool("isCrouch_down", crouch_down);
    }
}
