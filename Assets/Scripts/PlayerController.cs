
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BoxCollider2D playerCollider;
    public Animator animator;
    public Rigidbody2D rb2d;
    float sizeOfY, sizeOfY_Crouch, offsetOfY, offsetOfY_Crouch, horizontal, vertical;
    float speed = 5;
    float jumpMovement = 155;             
    int crouchTime;                     //new animation for crouch down so that player remains in crouch position till ctrl button is pressed
    int totalCrouchTime = 10;           //total time till crouch animation will run after that crouch down animation will start
    bool jump, isRun, crouch, crouch_down, crouchActionCheck = false;
    

    private void Awake()
    {
        
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        
        sizeOfY = playerCollider.size.y;
        sizeOfY_Crouch = playerCollider.size.y - 0.8f;
        offsetOfY = playerCollider.offset.y;
        offsetOfY_Crouch = playerCollider.offset.y - 0.4f;
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }

    //Update
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        crouchActionCheck = Input.GetKey(KeyCode.LeftControl);

        verticalMovementAnimation(vertical);
        crouchAction(crouchActionCheck);
        animatorPlayerFun();  //function for animator parameters
        transformPlayerFun();

    }

    //Vertical Movement Animation
    void verticalMovementAnimation(float vertical)
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
            crouchTime++;
            if (crouchTime >= totalCrouchTime)
            {
                crouch = true;
                crouch_down = true;
                isRun = false;
                speed = 0;
            }
            else
            {
                crouch = true;
                crouch_down = false;
                isRun = false;
                speed = 0;
            }

            
        }
        else
        {
            
            playerCollider.size = new Vector2(playerCollider.size.x, sizeOfY);
            playerCollider.offset = new Vector2(playerCollider.offset.x, offsetOfY);
            crouchTime = 0;
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
        animator.SetBool("isRunning", isRun);
    }
}
