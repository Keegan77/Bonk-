using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball2Right : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20.0f;

    GameObject gameManagerObj;
    GameManager gameManager;
    BoxCollider2D fireballcollider;
    GameObject Player2;
    Transform player1transform;
    BoxCollider2D player1collider;
    void Start()
    {
        //playerController = Player1.GetComponent<PlayerController>();
        gameManagerObj = GameObject.FindGameObjectWithTag("gamemanager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        player1collider = Player2.GetComponent<BoxCollider2D>();
        fireballcollider = GetComponent<BoxCollider2D>();
        player1transform = Player2.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -2f, Space.Self);
        transform.Translate((Vector2.right * 3) * Time.deltaTime, Space.World);

        if (transform.position.x > 10 || transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player1"))
        {
            if (gameManager.player1died == false)
            {
                gameManager.p2Score++;
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
