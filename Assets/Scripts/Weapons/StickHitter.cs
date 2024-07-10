using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickHitter : MonoBehaviour
{
    public float damage = 2f;
    public float hitTime = 0.0f;
    public float impulseTime = 1.0f;
    
    public GameObject ignoreCollider;

    private List<GameObject> hits;

    private void ApplyImpulse(GameObject victim, Vector3 force) {
        Rigidbody rb = victim.GetComponent<Rigidbody>();
        if (rb == null) return;

        rb.AddForce(force, ForceMode.Impulse);
    }

    private void DamageEnemies(GameObject victim) {
        PlayerHealth pm = victim.GetComponent<PlayerHealth>();
        if (pm != null) {
            pm.TakeDamage(damage);
        } else {
            EnemyHealth eh = victim.GetComponent<EnemyHealth>();
            if (eh != null) {
                eh.TakeDamage(damage);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       hits = new List<GameObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTime > 0.0f) {
            hitTime -= Time.deltaTime;
        } else if (hitTime <= 0.0f && hits.Count > 0) {
            hits.Clear();
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Hit: " + other.gameObject.name);
        if (hitTime > 0.0f) { 
            Vector3 otherPos = other.transform.position; otherPos.y = 0; otherPos = otherPos.normalized;
            Vector3 selfPos = transform.position; selfPos.y = 0; selfPos = selfPos.normalized;
            Vector3 knockBack = (otherPos - selfPos).normalized;
            ApplyImpulse(other.gameObject, knockBack * impulseTime);

            if (ignoreCollider != null && other.gameObject == ignoreCollider) return;
            if (hits.Contains(other.gameObject)) return;
    
            DamageEnemies(other.gameObject);
            hits.Add(other.gameObject);
        }
    }
}