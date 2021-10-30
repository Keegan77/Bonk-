using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int p1Score;
    public int p2Score;

    public Text p1ScoreText;
    public Text p2ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1ScoreText.text = $"P1: {p1Score}";
        p2ScoreText.text = $"P2: {p2Score}";
    }
}
