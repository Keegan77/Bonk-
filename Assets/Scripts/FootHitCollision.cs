using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHitCollision : MonoBehaviour
{
    GameManager gameManager;

    GameObject player1;
    GameObject player2;

    Rigidbody2D p1rb;
    Rigidbody2D p2rb;

    Transform p1transform;
    Transform p2transform;

    private float jumpForce = 19;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        p1rb = player1.GetComponent<Rigidbody2D>();
        p2rb = player2.GetComponent<Rigidbody2D>();
        p1transform = player1.GetComponent<Transform>();
        p2transform = player2.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
        }
        if (player2 == null)
        {
            player2 = GameObject.FindGameObjectWithTag("Player2");
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D otherrb;

        otherrb = collision.GetComponent<Rigidbody2D>();

        if (collision.CompareTag("Head"))
        {
            
            p2rb.velocity = Vector2.up * jumpForce;
            if (gameManager.player1died == false)
            {
                gameManager.p2Score++;
                Destroy(player1);
            }
            //p2rb.velocity = new Vector2((p1transform.position.x + p2transform.position.x) * 10, p2rb.velocity.y);
            //player2.transform.Translate(new Vector3((p1transform.position.x + p2transform.position.x), p2transform.position.y), 0);
        }

        if (collision.CompareTag("Head2"))
        {
            p1rb.velocity = Vector2.up * jumpForce;
            if (gameManager.player2died == false)
            {
                gameManager.p1Score++;
                Destroy(player2);
            }
            
            //p1rb.velocity = new Vector2((p1transform.position.x + p2transform.position.x) * 10, p1rb.velocity.y);
            //player1.transform.Translate(new Vector3((p1transform.position.x + p2transform.position.x), p1transform.position.y), 0);
        }
    }
    
}
