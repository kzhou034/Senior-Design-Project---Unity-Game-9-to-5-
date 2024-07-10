using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBeam : MonoBehaviour
{
    [Header("Press Z for laser, X for force blast")]

    [Header("Laser beam damage: 5")]
    
    [Header("Force blast damage: 20")]
    
    //initialize
    float cooldown = 0.0f;
    float projectileSpeed = 0.0f;
    int   projectileCount = 1;
    float projectileMomentum = 1.0f; 
    float projectileDamage = 0.0f;
    float projectileAOE = 0.0f;
    float projectileLifetime = 0.0f;
    
    public GameObject LaserBeamPrefab;
    public GameObject ForceBlastPrefab;
    private GameObject cam;
    private float lastFired = 0.0f;


    void FireLaserBeam() {
        GameObject bullet = Instantiate(LaserBeamPrefab);
        bullet.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.2f, cam.transform.position.z) + cam.transform.forward;
        print("laser position:" + bullet.transform.position);

        BulletBehavior bb = bullet.AddComponent<BulletBehavior>();
        bb.damage = projectileDamage;
        bb.timeOfImpulse = projectileMomentum;
        bb.areaOfEffect = projectileAOE;
        bb.lifetime = projectileLifetime;

        Rigidbody bphysor = bullet.GetComponent<Rigidbody>(); //apply a force

        Vector3 forward = cam.transform.forward.normalized;
        Vector3 up = Quaternion.Euler(90, -30, 0) * forward;
        Vector3 right = Vector3.Cross(forward, up);
        Vector3 dir = Quaternion.AngleAxis(0.0f, up) * Quaternion.AngleAxis(0.0f, right) * forward;
    
        bullet.transform.LookAt(bullet.transform.position + dir);
        bullet.transform.rotation *= LaserBeamPrefab.transform.rotation; //if prefab has some rotations in there, apply here
        bphysor.AddForce(dir * projectileSpeed, ForceMode.VelocityChange);
    }

    void FireForceBlast() {
        GameObject bullet = Instantiate(ForceBlastPrefab);
        bullet.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.2f, cam.transform.position.z) + cam.transform.forward;
        print("force blast position:" + bullet.transform.position);

        BulletBehavior bb = bullet.AddComponent<BulletBehavior>();
        bb.damage = projectileDamage;
        bb.timeOfImpulse = projectileMomentum;
        bb.areaOfEffect = projectileAOE;
        bb.lifetime = projectileLifetime;

        Rigidbody bphysor = bullet.GetComponent<Rigidbody>(); //apply a force

        Vector3 forward = cam.transform.forward.normalized;
        Vector3 up = Quaternion.Euler(90, -30, 0) * forward;
        Vector3 right = Vector3.Cross(forward, up);
        Vector3 dir = Quaternion.AngleAxis(0.0f, up) * Quaternion.AngleAxis(0.0f, right) * forward;
    
        bullet.transform.LookAt(bullet.transform.position + dir);
        bullet.transform.rotation *= ForceBlastPrefab.transform.rotation; //if prefab has some rotations in there, apply here
        bphysor.AddForce(dir * projectileSpeed, ForceMode.VelocityChange);
    }

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTimeOffset.Now.ToUnixTimeSeconds());

        cam = transform.Find("Main Camera").gameObject; 
        if (cam == null) {
            Debug.Log("No Main Camera?");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            cooldown = 2.0f; 
            projectileSpeed = 20;
            projectileMomentum = 1.0f; 
            projectileDamage = 15;
            projectileLifetime = 7.0f;
            if (Time.time - lastFired < cooldown) return;
            lastFired = Time.time;

            FireLaserBeam();

            int bulletCount = Mathf.Abs(projectileCount) - 1;
            for (int i = 0; i < bulletCount; i++) {
                FireLaserBeam();
            }
        }
        else if (Input.GetKeyDown(KeyCode.X)) {
            cooldown = 4.0f; 
            projectileSpeed = 8;
            projectileMomentum = 10.0f; 
            projectileDamage = 25;
            projectileLifetime = 7.0f;
            
            if (Time.time - lastFired < cooldown) return;
            lastFired = Time.time;

            FireForceBlast();

            int bulletCount = Mathf.Abs(projectileCount) - 1;
            for (int i = 0; i < bulletCount; i++) {
                FireForceBlast();
            }
        }
    }
}
