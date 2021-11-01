using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float currentTime;
    float startingTime = 3f;
    bool spawn = false;
    int spawnInt;

    public Text countdownText;
    public GameObject player1;
    public GameObject player2;
    public Transform Spawn1;
    public Transform Spawn2;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        print(currentTime);
        if (currentTime > 1)
        {
            countdownText.text = currentTime.ToString("0");
        }
        
        if (currentTime < 1 && currentTime > -1)
        {
            countdownText.text = "GO!";
            spawnInt += 1;

        }
        if (currentTime < -1)
        {
            Destroy(countdownText);

        }
        if (spawnInt == 1)
        {
            Instantiate(player1, new Vector3(Spawn1.position.x, Spawn1.position.y, Spawn1.position.z), transform.rotation);
            Instantiate(player2, new Vector3(Spawn2.position.x, Spawn2.position.y, Spawn2.position.z), transform.rotation);
        }

    }
}
