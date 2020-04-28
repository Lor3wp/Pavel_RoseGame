using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public bool dead;
    
    // Effects
    public ParticleSystem JumpDust;
    public ParticleSystem Dust;

    //Components
    public Rigidbody2D r2;
    public Animator myAnimator;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public PolygonCollider2D AC;
    public Transform wallCheck;
    public LayerMask whatIsWall;


    //PlayerInfo
    public bool facingRight;
    public bool fall;
    public bool isGrounded;
    public bool flipAcces;
    private bool startTimer = false;
    private float timer;


    //Jump/Move
    public float moveSpeed;
    public bool jump;
    public bool doubleJump;
    private float jumpForce = 16;
    public bool canMove;
    public float horizontal;

    [SerializeField]
    private float gravityScale = 1f;
    public bool pressedJump = false;
    private bool releasedJump = false;
    [SerializeField]
    private float jumpTimer = 0.5f;


    //attack
    public bool attack;
    public float attackTimer = 0;
    public float attackCd;
    public float knockDur;
    public float knockbackPwr;
    public bool attackKnockBack;
    public float atTimer;


    //Wall
    public float wallSlideSpeed;
    public bool onWall;
    public float angleR;
    public float angleL;
    public int WallJumpForce;

    //Ability openers


    //cameraSettings
    public CinemachineCameraOffset CMvcam;

    [SerializeField]
    private float waitTime = 0.05f;

    private float rememberDeltaTime;

    private void Awake()
    {
        canMove = true;
        flipAcces = true;
    }
    private void Start()
    {
        CMvcam = GetComponent<CinemachineCameraOffset>();



        facingRight = true;

        dead = false;

        r2 = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        timer = jumpTimer;
        if (instance == null)
        {
            instance = this;
        }
        myAnimator = GetComponent<Animator>();
        r2 = GetComponent<Rigidbody2D>();
        onWall = false;
        this.rememberDeltaTime = Time.timeScale;
        atTimer = 0;
        attack = false;
    }
    void Update()
    {
            
        HandleInput();

        if (startTimer)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                releasedJump = true;
            }
        }
      

    }

    private void FixedUpdate()
    {
         horizontal = Input.GetAxis("Horizontal");

        if (!dead)
        {

        HandleMovement(horizontal);
            if (GameManager.instance.attackAbility)
            {
                HandleAttack();
                HandleAttackCollider();
            }


        HandleFall();
        HandleLayers();
        flip(horizontal);
            
        ResetValues();

            if (GameManager.instance.JumpAbility)
            {
               if (pressedJump)
               {
                    StartJump();
                }

                if (releasedJump)
                {
                   StopJump();
               }
            }

            if (GameManager.instance.wallAbility)
            {
                WallJump();

                HandleWall();
            }


        }


        if(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            flipAcces = false;
        }



        




        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, whatIsGround);
        if (isGrounded)
        {
            doubleJump = true;
        }
        onWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, whatIsWall);
        if (PlayerMovement.instance.isGrounded)
        {
            onWall = false;
        }



        if (attackKnockBack)
        {
            if (knockDur >= atTimer)
            {
                canMove = false;
                atTimer += Time.deltaTime;
                if (!facingRight)
                {
                    r2.AddForce(Vector2.right * knockbackPwr);
                } else if (facingRight)
                {
                    r2.AddForce(Vector2.left * knockbackPwr);
                }

            } else
            {
                attackKnockBack = false;
                atTimer = 0;
                canMove = true;
            }


        }


    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dash")) 
        {
            doubleJump = false;
            r2.velocity = new Vector2(0f, 0f);
            pressedJump = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            releasedJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack = true;
        }

    }

    void HandleMovement(float horizontal)

    {
        if (canMove)
        {

            r2.velocity = new Vector2(horizontal * moveSpeed, r2.velocity.y);
            myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
            if (horizontal > 0.1 && isGrounded || horizontal < -0.1 && isGrounded)
            {
                CreateDust();
            }
        }
            if(r2.velocity.y > 9)
        {
            CreateJumpDust();
        }
        


    }

    private void HandleWall()
    {

        if (onWall)
        {
            myAnimator.SetBool("onWall", true);

            if (myAnimator.GetFloat("speed") > 0 && waitTime <= 0 || myAnimator.GetFloat("speed") < 0 && waitTime <= 0)
            {
                waitTime = 0.05f;
            }
            else
            {

                if (r2.velocity.y < moveSpeed)
                {
                    r2.velocity = new Vector2(0, wallSlideSpeed);
                    waitTime -= Time.deltaTime;
                }

            }

        }
        else
        {
            myAnimator.SetBool("onWall", false);
        }
        if (onWall && !isGrounded)
        {

            flipAcces = false;

            fall = false;

        } else
        {
            flipAcces = true;
        }

    }

    public void WallJump()
    {
        if (onWall && Input.GetKeyDown(KeyCode.Space) && facingRight)
        {
            Vector3 direction = Quaternion.AngleAxis(angleR, Vector3.forward) * Vector3.left;
            r2.AddForce(direction * WallJumpForce);
        }
        if (onWall && Input.GetKeyDown(KeyCode.Space) && !facingRight)
        {
            Vector3 direction = Quaternion.AngleAxis((angleL * -1), Vector3.forward) * Vector3.left;
            r2.AddForce(direction * WallJumpForce);
        }
    }
    private void StartJump()
    {
        r2.gravityScale = 0;
        r2.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        myAnimator.SetBool("jump", true);
        pressedJump = false;
        startTimer = true;
    }

    private void StopJump()
    {
        r2.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
    }



    void HandleFall()
    {
        if (r2.velocity.y < 0) {
            fall = true;
        } else if (r2.velocity.y >= 0) {
            fall = false;
        }
        if (fall && !attack) {
            myAnimator.SetBool("jump", false);
            myAnimator.SetBool ("fall", true);
            isGrounded = false;
        } else {
            myAnimator.SetBool ("fall", false);
        }

    }

    void HandleAttack()
    {
        if (attackTimer <= 0)
        {
            if (attack)
            {
                attackTimer = attackCd;
                if (!isGrounded)
                {
                    myAnimator.SetTrigger("atackA");
                } else
                {
                    myAnimator.SetTrigger("atackG");
                }

            }

        } else
        {
            attackTimer -= Time.deltaTime;
        }
    }
    public void knockBackTure()
    {
        
        r2.velocity = new Vector2(0,0);
        attackKnockBack = true;

    }
    void HandleAttackCollider()
    {
        if(this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("Attack2")|| this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            AC.enabled = true;
            flipAcces = false;

        }
        else
        {
            AC.enabled = false;
            flipAcces = true;

        }
    }

    void flip(float horizontal)
    {
        if (flipAcces)
        {
            if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
            {
                facingRight = !facingRight;

                Vector3 theScale = transform.localScale;

                theScale.x *= -1;

                transform.localScale = theScale;
            }
        }
    }

    void CreateJumpDust()
    {
        JumpDust.Play();
    }
    void CreateDust()
    {
        Dust.Play();
    }
    void ResetValues()
    {
        
        jump = false;
        
        
        attack = false;
        


    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else if (isGrounded)
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
    public void destroyObject()
    {
        Destroy(gameObject);
    }

}
