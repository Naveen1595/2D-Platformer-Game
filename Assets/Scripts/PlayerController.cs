
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{   
    [SerializeField]
    private BoxCollider2D playerCollider;

    [SerializeField]
    private FloatingFloorController floatingFloorController;

    [SerializeField]
    private GameOverController gameOverController;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rb2d;

    float sizeOfY, sizeOfY_Crouch, offsetOfY, offsetOfY_Crouch, horizontal, vertical;

    [SerializeField]
    private ScoreController scoreController;

    [SerializeField]
     private GameObject[] Heart;

    int lifeLeft = 2;
    float JumpCounter = 0f;
    float speed = 5f;
    float inJumpSpeed = 3.8f;
    float jumpMovement = 2.2f;             
    float crouchTime;                     //new animation for crouch down so that player remains in crouch position till ctrl button is pressed
    float totalCrouchTime = 10f;           //total time till crouch animation will run after that crouch down animation will start
    bool jump = false, isRun = false, crouch = false, crouch_down = false, crouchActionCheck = false, isDeath = false;
    string horizontalMovement = "Horizontal";
    string verticalMovement = "Vertical";
    float crouchPlayerSizeCollider = 0.8f;
    float crouchPlayerOffsetCollider = 0.4f;
    float restartPosition = -20f;

    Vector2 checkPoint1 = new Vector2(3f, 0f);


   


    //Awake 
    private void Awake()
    {
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sizeOfY = playerCollider.size.y;
        sizeOfY_Crouch = playerCollider.size.y - crouchPlayerSizeCollider;
        offsetOfY = playerCollider.offset.y;
        offsetOfY_Crouch = playerCollider.offset.y - crouchPlayerOffsetCollider;

    }

    private void FixedUpdate()
    {
        crouchAction(crouchActionCheck);
        playerHorizontalMovement(horizontal);
        verticalMovementAnimation(vertical);
    }

    //Update
    private void Update()
    {
        horizontal = Input.GetAxisRaw(horizontalMovement);
        vertical = Input.GetAxisRaw(verticalMovement);
        crouchActionCheck = Input.GetKey(KeyCode.LeftControl);

        animatorPlayerFun();  //function for animator parameters
        transformPlayerFun();
        restartPlayer();

    }

   
    public void pickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    public void PlayerKilledByChomper()
    {
        if(lifeLeft >= 0)
        {
            Heart[lifeLeft--].SetActive(false);
            gameObject.transform.position = checkPoint1;
            
        }
        else
        {
            gameOverController.PlayerDied();
            this.enabled = false;
        }
        
    }

    
    //Vertical Movement Animation
    void verticalMovementAnimation(float vertical)
    {
        
        if (vertical > 0)
        {
               JumpCounter += Time.deltaTime;
               if (JumpCounter <= 0.6f)
               {
                SoundManager.Instance.Play(Sounds.PlayerJump);
                jump = true;
                    rb2d.AddForce(new Vector2(0f, jumpMovement), ForceMode2D.Impulse);
     
               }
               else
               {
                    rb2d.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
               }
        }
        else
        {
            JumpCounter = 0;
            jump = false;
        }
     
    }

    //Crouch Action Animations
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
                speed = 0;
            }
            else
            {
                crouch = true;
                crouch_down = false;
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

    //Player Rotation 
    void transformPlayerFun()
    {
        //scale transform
        Vector3 scale = transform.localScale;       //Rotation of Player
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    
    //Horizontal Movement 
    void playerHorizontalMovement(float horizontal)
    {
        SoundManager.Instance.Play(Sounds.PlayerMove);
        Vector3 position = transform.position;
        if (jump == true)
        {
            position.x = position.x + horizontal * inJumpSpeed * Time.deltaTime;
        }
        else
        {
            position.x = position.x + horizontal * speed * Time.deltaTime;
        }
        
        
        transform.position = position;
        if (horizontal == 0 )
            isRun = false;
        else
            isRun = true;
    }

    //Restart level
    void restartPlayer()
    {

        if(gameObject.transform.position.y < restartPosition)
        {
            if (lifeLeft >= 0)
            {
                SoundManager.Instance.Play(Sounds.PlayerRestart);
                Heart[lifeLeft--].SetActive(false);
                gameObject.transform.position = checkPoint1;
            }
            else
            {
                gameOverController.PlayerDied();
                this.enabled = false;
            }
        }
    }
    //Animator Function
    void animatorPlayerFun()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("isJump", jump);
        animator.SetBool("isCrouch", crouch);
        animator.SetBool("isCrouch_down", crouch_down);
        animator.SetBool("isRunning", isRun);
        animator.SetBool("isDeath", isDeath);
    }
}
