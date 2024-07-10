using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    public float damage = 2;
    public float timeOfImpulse = 1.0f; //in seconds
    public float areaOfEffect = 0.0f;
    public float lifetime = 5; //in seconds

    public Transform playerHitBox; //please be set

    private float spawnTime;
    private Rigidbody physor;

    void Start()
    {
        spawnTime = Time.time;
        physor = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time - spawnTime >= lifetime) {
            Destroy(transform.gameObject);
        }
    }

    private void ApplyImpulseOn(GameObject hit, Vector3 force) {
        Rigidbody rb = hit.GetComponent<Rigidbody>();
        PlayerMovement pm = hit.GetComponent<PlayerMovement>();
        if (rb == null || pm != null) return; //No rigid body to move, and we don't want the player to get tossed around

        rb.AddForce(force, ForceMode.Impulse);
    }

    private float CalculateAreaDamage(Vector3 a, Vector3 b, Vector3 entityScale) {
        Vector3 vec = b - a;
        if (vec.magnitude < (areaOfEffect * 3.0f)) { //initial check to make sure that this is even plausible
            bool xCheck = (vec.x - entityScale.x) < areaOfEffect;
            bool yCheck = (vec.y - entityScale.y) < areaOfEffect;
            bool zCheck = (vec.z - entityScale.z) < areaOfEffect;

            if (xCheck && yCheck && zCheck) {
                return damage * Mathf.Clamp(1 - (vec.magnitude / areaOfEffect), 0, 1);
            }
        }

        return 0;
    }

    private void DamagePlayer(GameObject hit) {
        PlayerHealth pm = hit.GetComponent<PlayerHealth>();
        if (pm != null) {
            pm.TakeDamage(damage);
        } else { 
            pm = playerHitBox.parent.gameObject.GetComponent<PlayerHealth>();
            if (pm == null) {
                Debug.Log("Could not locate player script on player?");
                return;
            }

            float dmg = CalculateAreaDamage(transform.position, playerHitBox.position, playerHitBox.lossyScale);
            pm.TakeDamage(dmg);
        }
    }

    private GameObject[] GetAllEnemies() {
        List<GameObject> enemiesInRange = new List<GameObject>();

        GameObject[] roots = gameObject.scene.GetRootGameObjects();
        foreach (GameObject gmobj in roots) {
            EnemyHealth[] ebs = gmobj.GetComponentsInChildren<EnemyHealth>(false);
            foreach (EnemyHealth eb in ebs) {
                enemiesInRange.Add(eb.gameObject);
            }
        }

        return enemiesInRange.ToArray();
    }

    private void DamageEnemies(GameObject hit) {
        EnemyHealth ebhit = hit.GetComponent<EnemyHealth>();
        if (ebhit != null) {
            ebhit.TakeDamage(damage);
        }

        GameObject[] enemies = GetAllEnemies();
        foreach (GameObject enemy in enemies) {
            if (ebhit == null || enemy != ebhit.gameObject) { //no double dipping
                float aoeDmg = CalculateAreaDamage(transform.position, enemy.transform.position, enemy.transform.lossyScale);

                enemy.GetComponent<EnemyHealth>().TakeDamage(aoeDmg);
                if (aoeDmg > 0.1f) {
                    Vector3 vec = (enemy.transform.position - transform.position).normalized * 20.0f * (aoeDmg / damage);
                    ApplyImpulseOn(enemy, vec * physor.mass * timeOfImpulse);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<BulletBehavior>() != null) return;

        ApplyImpulseOn(other.gameObject, physor.velocity * physor.mass * timeOfImpulse);

        if (playerHitBox != null) DamagePlayer(other.gameObject);
        DamageEnemies(other.gameObject);

        Destroy(transform.gameObject); //will delete this bullet, script should be attached to root of bullet, not hitbox
    }
}
