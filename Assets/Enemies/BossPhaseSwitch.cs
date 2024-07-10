using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseSwitch : MonoBehaviour
{
    public GameObject EnemyPrefab;
    //public GameObject BulletSpawnPointObject;
    public GameObject ShooterPhase, MeleerPhase;

    float enemy_health;
    string enemy_type;
    int enemy_salary;

    // Start is called before the first frame update
    void Start()
    {
        enemy_health = EnemyPrefab.GetComponent<EnemyHealth>().health;
        EnemyPrefab.GetComponent<EnemyHealth>().enemyType = "shooter";
        enemy_type = EnemyPrefab.GetComponent<EnemyHealth>().enemyType;
        enemy_salary = EnemyPrefab.GetComponent<EnemyHealth>().salary;

        EnemyPrefab.GetComponent<TestEnemyLook>().enabled = true; //at start of fight, enemy looks at player
        //BulletSpawnPointObject.SetActive(true); //at start of fight, enemy shoots bullet object at player
        ShooterPhase.SetActive(true);

        EnemyPrefab.GetComponent<EnemyAI>().enabled = false; //at start of fight, enemy does not follow you
        EnemyPrefab.GetComponent<Rigidbody>().mass = 100;

        Debug.Log("Phase 1: " + enemy_type);
    }

    // Update is called once per frame
    void Update()
    {
        enemy_health = EnemyPrefab.GetComponent<EnemyHealth>().health;
        if(enemy_health <= 0) {
            Destroy(transform.gameObject);
        }

        if (enemy_health <= 2500) {
            EnemyPrefab.GetComponent<EnemyHealth>().enemyType = "melee";
            enemy_type = EnemyPrefab.GetComponent<EnemyHealth>().enemyType;
            Debug.Log("Phase 2: " + enemy_type);
        }

        if (enemy_type == "melee") {
            EnemyPrefab.GetComponent<EnemyAI>().enabled = true;//phase 2, melee enemy
            EnemyPrefab.GetComponent<TestEnemyLook>().enabled = false; 
            EnemyPrefab.GetComponent<Rigidbody>().mass = 1;
            //BulletSpawnPointObject.SetActive(false); 
            ShooterPhase.SetActive(false);
            MeleerPhase.SetActive(true);
        }
    }
}
