using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
     //public GameObject Player1;
     //public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //playerController = Player1.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            
            //playerController.hasPowerup=true;
            //Debug.Log("Power up Pick up!");
            //Destroy(gameObject);
        }
        
    }
    void Pickup()
    {
        
        
    }
}
