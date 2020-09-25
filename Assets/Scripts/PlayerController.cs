using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BoxCollider2D playerCollider;
    float sizeOfY, sizeOfY_Crouch, offsetOfY, offsetOfY_Crouch;
    int currentTime = 0;
    int CrouchTime = 10;
    public Animator animator;
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         Debug.Log("Collision" + collision.gameObject.name);
     }*/
    public void Start()
    {
        playerCollider = playerCollider.GetComponent<BoxCollider2D>();
        sizeOfY = playerCollider.size.y;
        sizeOfY_Crouch = playerCollider.size.y - 0.6f;
        offsetOfY = playerCollider.offset.y;
        offsetOfY_Crouch = playerCollider.offset.y - 0.25f;
    }

    
    public void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        bool jump = false;
        bool crouch = false;
        bool crouch_down = false;
        if (Input.GetAxisRaw("Vertical") > 0)
            {
                jump = true;
            }
        else 
        {
                jump = false;
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerCollider.size = new Vector2(playerCollider.size.x, sizeOfY_Crouch);
            playerCollider.offset = new Vector2(playerCollider.offset.x, offsetOfY_Crouch);
            currentTime++;
            Debug.Log("Current Time:" + currentTime);
            if(currentTime >= CrouchTime)
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

        
        /*Debug.Log("Vertical : " + jump);
        Debug.Log("Crouch : " + crouch);
        Debug.Log("Horizontal : " + speed);*/

        animator.SetFloat("Speed", Mathf.Abs(speed));
        animator.SetBool("isJump", jump);
        animator.SetBool("isCrouch", crouch);
        animator.SetBool("isCrouch_down", crouch_down);

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            animator.SetBool("isRunning", true);
        }
        else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("isRunning", true);
        }
        else if(speed == 0)
        {
            animator.SetBool("isRunning", false);
        }

        transform.localScale = scale;
    }
}
