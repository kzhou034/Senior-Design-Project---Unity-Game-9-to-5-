using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    private Transform playerReference;
    public Rigidbody bullet;
    private int flag = 0;
    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
        bullet = transform.GetComponent<Rigidbody>();

        Vector3 directionOfPlayer = (playerReference.position - transform.position).normalized;
        bullet.AddForce(directionOfPlayer * speed, ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")) { // damage player and destroy
            PlayerHealth playerhealth = collider.GetComponent<PlayerHealth>();
            if (flag == 0) {
                Debug.Log("Bullet collision with player detected!");
                playerhealth.TakeDamage();
                flag = 1;
            }       
            Destroy(gameObject);
        }
        if (!(collider.gameObject.CompareTag("Player"))) { //destroy on anything else
            Destroy(gameObject);
        }
    }
    
}
