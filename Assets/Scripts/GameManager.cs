using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    public bool gameWon = false;

    public GameObject player1prefab;
    public GameObject player2prefab;

    public Transform Spawner1;
    public Transform Spawner2;

    public int p1Score;
    public int p1scoreDeath;

    public int p2Score;
    public int p2scoreDeath;

    public Text p1ScoreText;
    public Text p2ScoreText;
    public bool justDied = false;

    public bool player2died = false;
    public bool player1died = false;
    bool startTimer = false;
    bool spawned;
    float currentTime;
    float startingTime = 1.5f;

    float powerSpawnTimeStart = 30;
    float currentPowerSpawnTime = 15;

    GameObject feetPosPlayer1;
    GameObject feetPosPlayer2;
    public GameObject FireballEmblem;

    public Transform powerUpSpawner;
    public Transform powerUpSpawner2;
    public Transform powerUpSpawner3;

    public BoxCollider2D feetPosPlayer1Coll;
    public BoxCollider2D feetPosPlayer2Coll;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        currentPowerSpawnTime -= Time.deltaTime;
        //print(currentPowerSpawnTime);
        if (currentPowerSpawnTime < 0)
        {
            spawned = true;
            currentPowerSpawnTime = powerSpawnTimeStart;
        }
        if (spawned)
        {
            int r = Random.Range(0, 3);
            switch (r)
            {
                case 0:
                    Instantiate(FireballEmblem, new Vector3(powerUpSpawner.position.x, powerUpSpawner.position.y, powerUpSpawner.position.z), transform.rotation);
                    break;
                case 1:
                    Instantiate(FireballEmblem, new Vector3(powerUpSpawner2.position.x, powerUpSpawner2.position.y, powerUpSpawner2.position.z), transform.rotation);
                    break;
                case 2:
                    Instantiate(FireballEmblem, new Vector3(powerUpSpawner3.position.x, powerUpSpawner3.position.y, powerUpSpawner3.position.z), transform.rotation);
                    break;
            }
            print(r);
            
            spawned = false;
        }
        //Debug.Log(p1scoreDeath);
        feetPosPlayer1 = GameObject.FindGameObjectWithTag("Player1Feet");
        feetPosPlayer2 = GameObject.FindGameObjectWithTag("Player2Feet");

        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        if (feetPosPlayer1 != null)
        {
            feetPosPlayer1Coll = feetPosPlayer1.GetComponent<BoxCollider2D>();
            //feetPosPlayer1Coll.isTrigger = false;
        }
        if (feetPosPlayer2 != null)
        {
            feetPosPlayer2Coll = feetPosPlayer2.GetComponent<BoxCollider2D>();
        }
        if (feetPosPlayer1Coll == null || feetPosPlayer2Coll == null)
        {
            feetPosPlayer1Coll = null;
            feetPosPlayer2Coll = null;
        }
        p1ScoreText.text = $"P1: {p1Score}";
        p2ScoreText.text = $"P2: {p2Score}";

        if (p1Score == p1scoreDeath + 1 && p1Score < 15)
        {
            //respawn player 2
            StartCoroutine(RespawnPlayer("Player 2"));
            p1scoreDeath = p1Score;
        }
        if (p2Score == p2scoreDeath + 1 && p2Score < 15)
        {
            //respawn player 1
            StartCoroutine(RespawnPlayer("Player 1"));
            p2scoreDeath = p2Score;
        }

        if (p1Score == 15 || p2Score == 15)
        {
            gameWon = true;
        }

        if (gameWon)
        {
            //if (Input.anyKeyDown && Input.GetKeyDown(KeyCode.Space) != true && Input.GetKeyDown(KeyCode.W) != true && Input.GetKeyDown(KeyCode.A) != true && Input.GetKeyDown(KeyCode.S) != true && Input.GetKeyDown(KeyCode.D) != true && Input.GetKeyDown(KeyCode.Alpha4) != true && Input.GetKeyDown(KeyCode.UpArrow) != true && Input.GetKeyDown(KeyCode.LeftArrow) != true && Input.GetKeyDown(KeyCode.RightArrow) != true && Input.GetKeyDown(KeyCode.DownArrow) != true && Input.GetKeyDown(KeyCode.V) != true && Input.GetKeyDown(KeyCode.Alpha5) != true)
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene(0); // This brings you back to the main menu
            }
        }
        
        if (startTimer)
        {
            currentTime = startingTime;
            startTimer = false;
        }
        //print(player1died);

        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            if (feetPosPlayer1Coll != null)
            {
                feetPosPlayer1Coll.isTrigger = true;
            }
            if (feetPosPlayer2Coll != null) 
            {
                feetPosPlayer2Coll.isTrigger = true;
            }
            player1died = false;
            player2died = false;
            
        }
        if (currentTime > 0)
        {
            if (player2died)
            {
                //feetPosPlayer1Coll.isTrigger = false;
                //player2.layer = 8;
            }
            //else player2.layer = 0;
            if (player1died)
            {
                //feetPosPlayer2Coll.isTrigger = false;
                //player1.layer = 8;
            }
            //else //player1.layer = 0;
        }


    }
    private IEnumerator RespawnPlayer(string player)
    {
        Debug.Log("Yo");
        yield return new WaitForSeconds(1);
        
        if (player == "Player 1")
        {
            Instantiate(player1prefab, new Vector3(Spawner1.position.x, Spawner1.position.y, Spawner1.position.z), transform.rotation);
            startTimer = true;
            player1died = true;
        }
        if (player == "Player 2")
        {
            Instantiate(player2prefab, new Vector3(Spawner2.position.x, Spawner2.position.y, Spawner2.position.z), transform.rotation);
            startTimer = true;
            player2died = true;
        }
    }
}
