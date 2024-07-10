using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    public float armor = 0;
    public string enemyType;
    public int score;
    public int salary;
    private int killFlag = 0;
    void Start() 
    {
        salary += Random.Range(1,20);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
    public void TakeDamage(float attack_damage) 
    {
        //formula for taking damage
        float reduction = armor / 100.0f;


        attack_damage -= attack_damage * reduction;
        health -= attack_damage;

        if(health <= 0) 
        {
            if(killFlag == 0) {
                PlayerStatistics playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatistics>();
                PlayerHealth PlayerSalary = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
                playerScore.addScore(score,enemyType);
                PlayerSalary.UpdateSalary(salary);
                killFlag = 1;
            }
            Destroy(transform.gameObject);
        }
    }

}
