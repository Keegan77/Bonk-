using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;
    private BoxCollider2D headCollider;
    GameObject head;
    BoxCollider2D platformcolliderhead;
    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.FindGameObjectWithTag("Head");
        headCollider = head.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentOneWayPlatform = collision.gameObject;
            platformcolliderhead = currentOneWayPlatform.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(headCollider, platformcolliderhead);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        
        yield return new WaitForSeconds(0.15f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        //Physics2D.IgnoreCollision(headCollider, platformCollider, false);
    }
}
