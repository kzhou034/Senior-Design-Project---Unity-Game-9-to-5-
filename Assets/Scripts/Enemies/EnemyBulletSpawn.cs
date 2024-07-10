using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    public float distance = 2f;
    public float cooldown = 10.0f;
    public GameObject bullet;

    private Transform enemyTransform; 
    private Transform bulletSpawn;
    private Animator animator;
    private float timePassed = 0f;


    void Start()
    {
        //Parent object (the enemy cylinder) gets saved as a reference by this - enemyTransform tracks the enemy rotation
        enemyTransform = transform.parent;
        bulletSpawn = transform.Find("Armature/Bone/Bone.001/Bone.004/Bone.005/Bone.016/Bone.016_end");

        if (bulletSpawn == null) {
            Debug.Log("No bullet spawn?");
        }

        animator = transform.GetComponentInChildren<Animator>();
    }

    void Update()
    {

        //Spawn bullet (play animation) every x seconds
        timePassed += Time.deltaTime;
        if(timePassed > cooldown)
        {
            animator.SetTrigger("Shoot");
        } 

    }

    public void ShootBullet() { //Being Called by an Animation Event externally
        //Spawner position and rotation
        Vector3 spawnPos = bulletSpawn.position + enemyTransform.forward * distance; //Set the spawner position

        transform.position = spawnPos;
        transform.rotation = enemyTransform.rotation;

        //Spawn bullet here
        //Instantiate(bullet, transform.position, Quaternion.identity);
        Instantiate(bullet, transform.position, transform.rotation);
        timePassed = 0f;
    }

}
