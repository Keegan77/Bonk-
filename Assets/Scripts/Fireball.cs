using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
     public GameObject Player1;
     public GameObject Player2;
     public PlayerController playerController;
    // Start is called before the first frame update
    public float speed=20.0f;
    
    GameObject gameManagerObj;
    GameManager gameManager;
    void Start()
    {
        //playerController = Player1.GetComponent<PlayerController>();
        gameManagerObj = GameObject.FindGameObjectWithTag("Gamemanager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
     }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
           Destroy(other.gameObject);
           Destroy(gameObject);
           gameManager.p2Score++;
        
           
        }
        else if(other.CompareTag("Player2"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.p1Score++;
        
        }
    }
    
    
    
}
