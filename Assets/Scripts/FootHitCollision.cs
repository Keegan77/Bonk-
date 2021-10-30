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
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D otherrb;

        otherrb = collision.GetComponent<Rigidbody2D>();

        if (collision.CompareTag("Head"))
        {
            gameManager.p2Score++;
            p2rb.velocity = Vector2.up * jumpForce;
            //p2rb.velocity = new Vector2((p1transform.position.x + p2transform.position.x) * 10, p2rb.velocity.y);
            //player2.transform.Translate(new Vector3((p1transform.position.x + p2transform.position.x), p2transform.position.y), 0);
        }

        if (collision.CompareTag("Head2"))
        {
            gameManager.p1Score++;
            p1rb.velocity = Vector2.up * jumpForce;
            //p1rb.velocity = new Vector2((p1transform.position.x + p2transform.position.x) * 10, p1rb.velocity.y);
            //player1.transform.Translate(new Vector3((p1transform.position.x + p2transform.position.x), p1transform.position.y), 0);
        }
    }
}
