using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(p1scoreDeath);
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
    }
    private IEnumerator RespawnPlayer(string player)
    {
        Debug.Log("Yo");
        yield return new WaitForSeconds(1);
        
        if (player == "Player 1")
        {
            Instantiate(player1prefab, new Vector3(Spawner1.position.x, Spawner1.position.y, Spawner1.position.z), transform.rotation);
        }
        if (player == "Player 2")
        {
            Instantiate(player2prefab, new Vector3(Spawner2.position.x, Spawner2.position.y, Spawner2.position.z), transform.rotation);
        }
    }
}
