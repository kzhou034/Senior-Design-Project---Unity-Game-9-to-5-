using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public Transform Terrain;
    private Vector3 movementVector = Vector3.zero;
    public float moveSpeed = 4f;

    private Animator animController;


    // Start is called before the first frame update
    void Start()
    {
        // movementVector = (target.position - transform.position).normalized * moveSpeed;
        animController = transform.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > Terrain.position.y){
            movementVector = new Vector3(0f, -9.81f*Time.deltaTime, 0f);
        }
        //by default, we'll have the enemy just march at the player.
        // movementVector = (target.position - transform.position).normalized * moveSpeed;
        // transform.position += movementVector * Time.deltaTime;
        if (this.transform.position.y - movementVector.y < Terrain.position.y){
            transform.position = new Vector3(this.transform.position.x, Terrain.position.y, this.transform.position.z);
            movementVector.y = 0;
        }

        if (Math.Abs(target.position.x - this.transform.position.x) <= 1 && Math.Abs(target.position.z - this.transform.position.z) <= 1) {
            transform.position = this.transform.position;
        } else transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y,this.transform.position.z),new Vector3(target.position.x, this.transform.position.y, target.position.z)+movementVector, moveSpeed * Time.deltaTime);
    }
}