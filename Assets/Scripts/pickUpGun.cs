using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpGun : MonoBehaviour
{
    //reference to gun script
    public Shooter gunscript;
    public Meleer melee; 
    //reference to the weapons rigidbody
    //public Rigidbody rb;
    //
    //public BoxCollider collider;
    public Transform player;
    public Transform configurations;
    public float range; 
    public string currentWeapon;
    public GameObject staplerPrefab;
    public GameObject stapleProjectilePrefab;
    public GameObject penPrefab;
    public GameObject penRocketPrefab;
    public GameObject keyboardPrefab;
    public GameObject keyCapPrefab;
    public GameObject projectorPrefab; // Add the correct prefab for projector
    public GameObject projectorProjectilePrefab;
    //public float forwardForce, upwardForce;
    //public bool equiped;
    public GameObject mopPrefab;
    public GameObject hdmiPrefab;
    public bool[] weaponWheel;
    public WeaponUIOverlay weaponUIOverlay;
    // Start is called before the first frame update
    void Start()
    {
        weaponWheel = new bool[6];
        if(PlayerPrefs.GetInt("Stapler") == 1){
            weaponWheel[0] = true;
        }
        if(PlayerPrefs.GetInt("Pen") == 1){
            weaponWheel[1] = true;
        }
        if(PlayerPrefs.GetInt("Keyboard") == 1){
            weaponWheel[2] = true;
        }
        if(PlayerPrefs.GetInt("Projector") == 1){
            weaponWheel[3] = true;
        }
        if(PlayerPrefs.GetInt("HDMI") == 1){
            weaponWheel[4] = true;
        }
        if(PlayerPrefs.GetInt("Mop") == 1){
            weaponWheel[5] = true;
        }

        if(PlayerPrefs.GetInt("currWeapon") == 0){
            pickUp("stapler");
        }
        else if(PlayerPrefs.GetInt("currWeapon") == 1){
            pickUp("pen");
        }
        else if(PlayerPrefs.GetInt("currWeapon") == 2){
            pickUp("keyboard");
        }
        else if(PlayerPrefs.GetInt("currWeapon") == 3){
            pickUp("projector");
        }
        else if(PlayerPrefs.GetInt("currWeapon") == 4){
            pickUp("hdmi");
        }
        else if(PlayerPrefs.GetInt("currWeapon") == 5){
            pickUp("mop");
        }
    }

    // Update is called once per frame
    void Update() 
    {
        
        //check keycap pressed and call switch weapon
        if (Input.anyKeyDown)
        {
            // Get the key pressed as a string
            string keyPressed = Input.inputString;

            // If a key was pressed, it will be stored in keyPressed
            if (!string.IsNullOrEmpty(keyPressed))
            {
                swap(keyPressed);
            }
        }
        /*
        for (int i = 0; i < weaponWheel.Length; i++) {
            if (weaponWheel[i]) {
                if (weaponUIOverlay.weaponNames[i] == currentWeapon) {
                    weaponUIOverlay.LoadAndSetImage(weaponUIOverlay.imagePathsEquipped[i], weaponUIOverlay.weaponSlotImages[i]);
                }
                else {
                    weaponUIOverlay.LoadAndSetImage(weaponUIOverlay.imagePathsUnequipped[i], weaponUIOverlay.weaponSlotImages[i]);
                }
            }
        }
        */
    }
    // {
    //     Vector3 distance = player.position - transform.position; //check if within range
    //     //Debug.Log(transform.position);
    //     if(Input.GetKeyDown(KeyCode.E)) 
    //     {
    //         Debug.Log("E pressed");
    //     }
    //     //if(distance.magnitude <= range && Input.GetKeyDown(KeyCode.E)) //if no weapon euiped and within distance and E is pressed call pickup
    //     //    pickUp();
    // }
    public void configurateRangedWeapon(string name)
    {
        gunscript.reloadTime = configurations.Find(name).transform.GetComponent<WeaponConfigs>().reloadTime;
        gunscript.projectileSpeed = configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileSpeed;
        gunscript.projectileCount = configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileCount;
        gunscript.projectileMomentum = configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileMomentum;
        gunscript.projectileSpread = configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileSpread;
        gunscript.projectileDamage = configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileDamage;
        gunscript.projectileAOE = configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileAOE;
        gunscript.projectileLifetime = configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileLifetime;
    }

    public void configurateMeleeWeapon(string name)
    {
        melee.hitMomentum = configurations.Find(name).transform.GetComponent<WeaponConfigs>().hitMomentum;
        melee.hitDamage = configurations.Find(name).transform.GetComponent<WeaponConfigs>().hitDamage;
        melee.cooldownTime = configurations.Find(name).transform.GetComponent<WeaponConfigs>().cooldownTime;
    }

    public void pickUp(string tag) 
    {
        if(tag == "stapler") 
        {
            if(melee.enabled) 
            {
                melee.enabled = false;
                melee.replace();
            }
            if(!gunscript.enabled)
                gunscript.enabled = true;
            configurateRangedWeapon("Stapler");
            currentWeapon = "Stapler";
            gunscript.gunPrefab = staplerPrefab;
            gunscript.projectilePrefab = stapleProjectilePrefab;

            weaponWheel[0] = true;
            PlayerPrefs.SetInt("Stapler", 1);
            PlayerPrefs.SetInt("currWeapon", 0);
            gunscript.isEquiped = true;

            gunscript.RegenerateWeapon();
        }
        //pen
        else if(tag == "pen") 
        {
            if(melee.enabled) 
            {
                melee.enabled = false;
                melee.replace();
            }
            if(!gunscript.enabled)
                gunscript.enabled = true;
            configurateRangedWeapon("Pen");
            currentWeapon = "Pen";

            gunscript.gunPrefab = penPrefab;
            gunscript.projectilePrefab = penRocketPrefab;

            weaponWheel[1] = true;
            PlayerPrefs.SetInt("Pen", 1);
            PlayerPrefs.SetInt("currWeapon", 1);
            gunscript.isEquiped = true;

            gunscript.RegenerateWeapon();
        }//keyboard
        else if(tag == "keyboard") 
        {
            if(melee.enabled) 
            {
                melee.enabled = false;
                melee.replace();
            }
            if(!gunscript.enabled)
                gunscript.enabled = true;
            configurateRangedWeapon("Keyboard");
            currentWeapon = "Keyboard";

            gunscript.gunPrefab = keyboardPrefab;
            gunscript.projectilePrefab = keyCapPrefab;

            weaponWheel[2] = true;
            PlayerPrefs.SetInt("Keyboard", 1);
            PlayerPrefs.SetInt("currWeapon", 2);
            gunscript.isEquiped = true;

            gunscript.RegenerateWeapon();
        }//projector
        else if(tag == "projector") 
        {
            if(melee.enabled) 
            {
                melee.enabled = false;
                melee.replace();
            }
            if(!gunscript.enabled)
                gunscript.enabled = true;
            configurateRangedWeapon("Projector");
            currentWeapon = "Projector";

            gunscript.gunPrefab = projectorPrefab;
            gunscript.projectilePrefab = projectorProjectilePrefab;

            weaponWheel[3] = true;
            PlayerPrefs.SetInt("Projector", 1);
            PlayerPrefs.SetInt("currWeapon", 3);
            gunscript.isEquiped = true;

            gunscript.RegenerateWeapon();
        }//hdmi
        else if(tag == "hdmi")
        {
            if(gunscript.enabled) 
            {
                gunscript.enabled = false;
                gunscript.replace();
            }
            if(!melee.enabled)
                melee.enabled = true;
            configurateMeleeWeapon("HDMI");
            currentWeapon = "HDMI";

            melee.meleePrefab = hdmiPrefab;
            weaponWheel[4] = true;
            PlayerPrefs.SetInt("HDMI", 1);
            PlayerPrefs.SetInt("currWeapon", 4);
            melee.RegenerateWeapon();
        }//mop
        else if(tag == "mop") 
        {
            if(gunscript.enabled) 
            {
                gunscript.enabled = false;
                gunscript.replace();
            }
            if(!melee.enabled)
                melee.enabled = true;
            configurateRangedWeapon("Mop");
            currentWeapon = "Mop";

            melee.meleePrefab = mopPrefab;
            weaponWheel[5] = true;
            PlayerPrefs.SetInt("Mop", 1);
            PlayerPrefs.SetInt("currWeapon", 5);
            melee.RegenerateWeapon();
        }

        
    }
    private void swap(string key) 
    {
        //swap weapons
        switch (key)
        {
            case "1": //swap to stapler
                if(weaponWheel[0]) //check if equiped
                {
                    //check if gunscript active
                    if(melee.enabled) 
                    {
                        melee.enabled = false;
                        melee.replace();
                    }
                    if(!gunscript.enabled)
                        gunscript.enabled = true;
                    configurateRangedWeapon("Stapler");
                    currentWeapon = "Stapler";
                    PlayerPrefs.SetInt("currWeapon", 0);

                    gunscript.gunPrefab = staplerPrefab;
                    gunscript.projectilePrefab = stapleProjectilePrefab;

                    
                    gunscript.isEquiped = true;

                    gunscript.RegenerateWeapon();
                }
                break;
            case "2": //swap to penrocket
                if(weaponWheel[1]) 
                {
                    if (melee.enabled)
                    {
                        melee.enabled = false;
                        melee.replace();
                    }
                    if (!gunscript.enabled)
                        gunscript.enabled = true;
                    configurateRangedWeapon("Pen");
                    currentWeapon = "Pen";
                    PlayerPrefs.SetInt("currWeapon", 1);

                    gunscript.gunPrefab = penPrefab;
                    gunscript.projectilePrefab = penRocketPrefab;

                    gunscript.isEquiped = true;

                    gunscript.RegenerateWeapon();
                }
                break;
            case "3": //swap to keyboard
                if(weaponWheel[2]) 
                {
                    if (melee.enabled)
                    {
                        melee.enabled = false;
                        melee.replace();
                    }
                    if (!gunscript.enabled)
                        gunscript.enabled = true;
                    configurateRangedWeapon("Keyboard");
                    currentWeapon = "Keyboard";
                    PlayerPrefs.SetInt("currWeapon", 2);

                    gunscript.gunPrefab = keyboardPrefab;
                    gunscript.projectilePrefab = keyCapPrefab;

                    gunscript.isEquiped = true;

                    gunscript.RegenerateWeapon();
                }
                break;
            case "4": //swap to 
                if(weaponWheel[3]) 
                {
                    if (melee.enabled)
                    {
                        melee.enabled = false;
                        melee.replace();
                    }
                    if (!gunscript.enabled)
                        gunscript.enabled = true;
                    configurateRangedWeapon("Projector");
                    currentWeapon = "Projector";
                    PlayerPrefs.SetInt("currWeapon", 3);

                    gunscript.gunPrefab = projectorPrefab;
                    gunscript.projectilePrefab = projectorProjectilePrefab;

                    gunscript.isEquiped = true;

                    gunscript.RegenerateWeapon();
                }
                break;
            case "5": //swap to hdmi
                if(weaponWheel[4]) 
                {
                    if(gunscript.enabled) 
                    {
                        gunscript.enabled = false;
                        gunscript.replace();
                    }
                    if(!melee.enabled)
                        melee.enabled = true;
                    configurateMeleeWeapon("HDMI");
                    currentWeapon = "HDMI";
                    PlayerPrefs.SetInt("currWeapon", 4);
                    melee.meleePrefab = hdmiPrefab;
                    melee.RegenerateWeapon();
                    //weaponWheel[4] = true;
                }
                break;
            case "6": //swap to mop
                if(weaponWheel[5]) 
                {
                    if(gunscript.enabled) 
                    {
                        gunscript.enabled = false;
                        gunscript.replace();
                    }
                    if(!melee.enabled)
                        melee.enabled = true;
                    configurateMeleeWeapon("Mop");
                    currentWeapon = "Mop";
                    PlayerPrefs.SetInt("currWeapon", 5);
                    melee.meleePrefab = mopPrefab;
                    melee.RegenerateWeapon();
                }
                break;
            default:
                break;
        }
    }

    
    
}
