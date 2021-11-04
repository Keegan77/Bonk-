using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball1Left : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20.0f;

    GameObject gameManagerObj;
    GameManager gameManager;
    BoxCollider2D fireballcollider;
    GameObject Player1;
    Transform player1transform;
    BoxCollider2D player1collider;
    void Start()
    {
        //playerController = Player1.GetComponent<PlayerController>();
        gameManagerObj = GameObject.FindGameObjectWithTag("gamemanager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        player1collider = Player1.GetComponent<BoxCollider2D>();
        fireballcollider = GetComponent<BoxCollider2D>();
        player1transform = Player1.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -2f, Space.Self);

        transform.Translate((Vector2.left * 3) * Time.deltaTime, Space.World);

        if (transform.position.x > 10 || transform.position.x < -10)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player2"))
        {
            if (gameManager.player2died == false)
            {
                gameManager.p1Score++;
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }

    }

}
