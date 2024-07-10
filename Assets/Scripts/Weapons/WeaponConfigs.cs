using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConfigs : MonoBehaviour
{ //hehe
    [Header("Ranged Weapon Configurations")]
    public float reloadTime;
    public float projectileSpeed;
    public int projectileCount;
    public float projectileSpread;
    public float projectileMomentum;
    public float projectileDamage;
    public float projectileAOE;
    public float projectileLifetime;

    [Header("Melee Weapon Configations")]
    public float cooldownTime;
    public float hitMomentum;
    public float hitDamage;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(this.gameObject.name == "Stapler");
        // GameObject stapler = GameObject.Find("FPS Player").transform.Find("Weapon Configurations").transform.Find("Stapler");
        //if playerprefs is not initialized then we know it is set to the default values; otherwise, if they are already initialized then we are currently in the game
        if(this.gameObject.name == "Stapler" || this.gameObject.name == "Pen" || this.gameObject.name == "Keyboard" || this.gameObject.name == "Projector" ){
            if(this.gameObject.transform.parent.gameObject.name == "Weapon Configurations"){
                reloadTime = PlayerPrefs.GetFloat(this.gameObject.name + "ReloadTime");
                Debug.Log("this is " + this.gameObject.name + ": " + reloadTime);
                projectileSpeed = PlayerPrefs.GetFloat(this.gameObject.name + "ProjectileSpeed");
                projectileCount = PlayerPrefs.GetInt(this.gameObject.name + "ProjectileCount");
                projectileSpread = PlayerPrefs.GetFloat(this.gameObject.name + "ProjectileSpread");
                projectileMomentum = PlayerPrefs.GetFloat(this.gameObject.name + "ProjectileMomentum");
                projectileDamage = PlayerPrefs.GetFloat(this.gameObject.name + "ProjectileDamage");
                projectileAOE = PlayerPrefs.GetFloat(this.gameObject.name+ "ProjectileAOE");
                projectileLifetime = PlayerPrefs.GetFloat(this.gameObject.name + "ProjectileLifetime");
            }
            else{
                reloadTime = 0;
                projectileSpeed = 0;
                projectileCount = 0;
                projectileSpread = 0;
                projectileMomentum = 0;
                projectileDamage = 0;
                projectileAOE = 0;
                projectileLifetime = 0;
            }
        }

        if(this.gameObject.name == "Mop" || this.gameObject.name == "HDMI"){
            if(this.gameObject.transform.parent.gameObject.name == "Weapon Configurations"){
                cooldownTime = PlayerPrefs.GetFloat(this.gameObject.name + "CooldownTime");
                hitMomentum = PlayerPrefs.GetFloat(this.gameObject.name + "HitMomentum");
                hitDamage = PlayerPrefs.GetFloat(this.gameObject.name + "HitDamage");
            }
            else{
                cooldownTime = 0;
                hitMomentum = 0;
                hitDamage = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
