using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Weapons are placed based on camera aspect ratio.\nThis scales their place.")]
    public float weaponPositionRatio = 1.5f;
    public bool rightHandedWeapon = true;

    [Header("Weapon Configuration")]
    public float reloadTime = 1f;
    public float projectileSpeed = 25;
    public int   projectileCount = 1;
    public float projectileSpread = 10.0f; //in degrees
    public float projectileMomentum = 1.0f; //tracks to timeOfImpulse of BulletBehaviour
    public float projectileDamage = 2;
    public float projectileAOE = 0; //only affects rocket projectile behaviour
    public float projectileLifetime = 5.0f;
    
    [Header("Should primarily be updated by Scripts")]
    public GameObject gunPrefab;
    public GameObject projectilePrefab;

    public bool isEquiped; 

    private GameObject gunModel;
    private GameObject cam;
    private float lastFired = 0;

    public void RegenerateWeapon() {
        //TODO: Make this able to attach to ranged enemies
        if (gunModel != null) {
            Destroy(gunModel);
        }

        gunModel = Instantiate(gunPrefab, transform.Find("Main Camera"), true); //create the model of the gun
        gunModel.transform.rotation = Quaternion.LookRotation(transform.Find("Main Camera").forward,transform.Find("Main Camera").up) * gunModel.transform.rotation;

        Destroy(gunModel.GetComponent<Rigidbody>());
        Destroy(gunModel.GetComponent<BoxCollider>()); //don't fall anymore
    }

    public void replace() 
    {
        Destroy(gunModel);
    }

    void FireProjectile(float xScalar = 0, float yScalar = 0) {
        //print("(" + xScalar + ", " + yScalar + ")");
        GameObject bullet = Instantiate(projectilePrefab);
        bullet.transform.position = cam.transform.position + cam.transform.forward*(1+bullet.transform.lossyScale.z);

        BulletBehavior bb = bullet.AddComponent<BulletBehavior>();
        bb.damage = projectileDamage;
        bb.timeOfImpulse = projectileMomentum;
        bb.areaOfEffect = projectileAOE;
        bb.lifetime = projectileLifetime;

        Rigidbody bphysor = bullet.GetComponent<Rigidbody>(); //apply a force

        Vector3 forward = cam.transform.forward.normalized;
        Vector3 up = Quaternion.Euler(90, 0, 0) * forward;
        Vector3 right = Vector3.Cross(forward, up);
        Vector3 dir = Quaternion.AngleAxis(xScalar * projectileSpread, up) * Quaternion.AngleAxis(yScalar * projectileSpread, right) * forward;
    
        bullet.transform.LookAt(bullet.transform.position + dir);
        bullet.transform.rotation *= projectilePrefab.transform.rotation; //if prefab has some rotations in there, apply here
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

        RegenerateWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        float aspectRatio = cam.GetComponent<Camera>().aspect / weaponPositionRatio;
        float rhand = (rightHandedWeapon) ? 1 : -1;
        if(isEquiped)
            gunModel.transform.localPosition = new Vector3((1 / aspectRatio) * rhand, 0, aspectRatio); //always scale on aspect ratio

        if (Input.GetMouseButtonDown(0)) {
            if (Time.time - lastFired < reloadTime) return;
            lastFired = Time.time;

            FireProjectile();

            int bulletCount = Mathf.Abs(projectileCount) - 1;
            for (int i = 0; i < bulletCount; i++) {
                FireProjectile(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            }
        }
    }
}
