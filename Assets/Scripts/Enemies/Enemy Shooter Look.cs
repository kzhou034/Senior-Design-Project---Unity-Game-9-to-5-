using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyLook : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerReference;

    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        Vector3 directionOfPlayer = Camera.main.transform.position - transform.position; //get the direction
        directionOfPlayer.y = 0f; //no need for y component
        transform.LookAt(directionOfPlayer + transform.position);
        */
        
        //Trying without using the main camera, maybe will perform better
        Vector3 playerDirection = playerReference.position - transform.position;
        playerDirection.y = 0;

        if (playerDirection != Vector3.zero){
            transform.LookAt(transform.position + playerDirection);
        }

    }
}
//work pls
