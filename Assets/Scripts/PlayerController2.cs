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

    private float ylimit = 7;
    private float xlimit = 9.5f;
    public float maxYVelocity = -50;
    public bool hasPowerup=false;

    public Transform player2Transform;
    public Transform player1Transform;
    //Gets Rigidbody component
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        hasPowerup=false;
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
        if (other.CompareTag("Fireball"))
        {
            hasPowerup=true;
            
            Destroy(other.gameObject);
            
            Debug.Log("Power up Pick up!");
            
    }   }
    private void OnCollisonEnter2D(Collider collision)
    {
        Debug.Log("Test");
        if (collision.gameObject.CompareTag("Player1")&& hasPowerup)
        {
            
            Rigidbody2D Player1Rb= collision.gameObject.GetComponent<Rigidbody2D>();
            if (player2Transform.position.x > player1Transform.position.x) {
                Player1Rb.velocity = Vector2.left * 19;
            }
            else if (player2Transform.position.x < player1Transform.position.x) {
                Player1Rb.velocity = Vector2.right * 19;
            }
            //Vector2 awayPlayer2= collision.gameObject.transform.position+transform.position;
            //Player1Rb.AddForce(awayPlayer2*100,ForceMode2D.Impulse);
            //Player1Rb.velocity
        }
    }
    
    void Update()
    {
        //powerups
        if (hasPowerup) {

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

        else if (rb.velocity.y > 0 && Input.GetKey(KeyCode.Alpha4))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        //fixed double jump bug
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            isJumping = false;
        }

        //lets player jump

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Alpha4) && isJumping == false)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        //makes you jump higher when you hold down space
        if (Input.GetKey(KeyCode.Alpha4) && isJumping == true)
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
    }
}
