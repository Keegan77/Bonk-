using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    [Header("Layer Mask")]
    private bool isGrounded;
    public Transform feetPos;
    public Transform headPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    [Header("Jump")]
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    [Header("fall physics")]
    public float fallMultiplier;
    public float lowJumpMultiplier;

    private float ylimit = 5.5f;
    private float xlimit = 9.5f;
    public float maxYVelocity = -50;
    public bool hasFirePower = false;
    bool gotPowerUp = false;

    float firePowerCurrentTime;
    float firePowerStartingTime = 8;

    public Transform player2Transform;
    public Transform player1Transform;

    float fireCooldownCurrent;
    float fireCooldownStarting = .75f;

    Animator animator;
    GameObject GameManagerObj;
    GameManager gameManager;
    public GameObject Fireball;
    public GameObject FireballLeft;
    //Gets Rigidbody component
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        GameManagerObj = GameObject.FindGameObjectWithTag("gamemanager");
        gameManager = GameManagerObj.GetComponent<GameManager>();
        hasFirePower = false;
    }

    //Moves player on x axis

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal2");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    //Fireball interation
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FireUp"))
        {
            gotPowerUp = true;

            Destroy(other.gameObject);

            Debug.Log("Power up Pick up!");

        }
    }   
    
    void Update()
    {
        //powerups
        print(animator);
        firePowerCurrentTime -= Time.deltaTime;
        //print(firePowerCurrentTime);
        //Debug.Log(rb.velocity.y);
        if (gotPowerUp == true)
        {
            firePowerCurrentTime = firePowerStartingTime;
            hasFirePower = true;
            fireCooldownCurrent = 0;
            gotPowerUp = false;
        }
        if (hasFirePower)
        {
            fireCooldownCurrent -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.L))
            {
                if (transform.localScale.x == 1 && fireCooldownCurrent < 0)
                {
                    Instantiate(Fireball, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    fireCooldownCurrent = fireCooldownStarting;
                }
                else if (transform.localScale.x == -1 && fireCooldownCurrent < 0)
                {
                    Instantiate(FireballLeft, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    fireCooldownCurrent = fireCooldownStarting;
                }

                if (firePowerCurrentTime < 0)
                {
                    hasFirePower = false;
                }
            }
        }

        //Debug.Log(rb.velocity.y);
        if (rb.velocity.y < maxYVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxYVelocity);
        }
        if (transform.position.y < -ylimit)
        {
            transform.position = new Vector3(transform.position.x, ylimit, transform.position.z);
        }
        if (transform.position.y > ylimit)
        {
            transform.position = new Vector3(transform.position.x, -ylimit, transform.position.z);
        }
        if (transform.position.x > xlimit)
        {
            transform.position = new Vector3(-xlimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xlimit)
        {
            transform.position = new Vector3(xlimit, transform.position.y, transform.position.z);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //cool jump fall

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (rb.velocity.y > 0 && Input.GetKey(KeyCode.Alpha4))
        {
            if (Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.K))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        //fixed double jump bug
        if (Input.GetKeyUp(KeyCode.Alpha4) || Input.GetKeyUp(KeyCode.K))
        {
            isJumping = false;
        }

        //lets player jump

        if (isGrounded == true && (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.K)) && isJumping == false)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        //makes you jump higher when you hold down space
        if ((Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.K)) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                //rb.velocity = Vector2.up * jumpForce;
                //jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        animator.SetBool("Invincible", gameManager.player2died);
        animator.SetBool("fire", hasFirePower);
    }
}
