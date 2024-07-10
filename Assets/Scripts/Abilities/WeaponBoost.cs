using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoost : MonoBehaviour
{
    [Header("ADD THE REST OF THE WEAPONS TO THIS")]
    //melee weapons currently commented out

    [Header("Get components from fps player, get names of weapons")]
    [Header("Depending on which weapon is active, different upgrades")]
    public GameObject FPSPlayerPrefab;
    public GameObject StaplerPrefab; //stapler upgrade: +8 damage
    public GameObject PenPrefab; //pen upgrade: +1 dmg, +8 projectiles

    private int timesPressed = 0;

    // Start is called before the first frame update
    void Start()
    {
        print("starting projectile damage: " + FPSPlayerPrefab.GetComponent<Shooter>().projectileDamage);
        print("holding weapon: " + FPSPlayerPrefab.GetComponent<Shooter>().gunPrefab);
        timesPressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ranged_weapon = FPSPlayerPrefab.GetComponent<Shooter>().gunPrefab;
        //GameObject melee_weapon = FPSPlayerPrefab.GetComponent<Meleer>().meleePrefab;

        if (timesPressed == 0) {
            if (Input.GetKeyDown(KeyCode.I)) {
                print("increasing weapon damage");
                
                //ranged weapons
                if (ranged_weapon.name == "Stapler") {
                    print("weapon: " + ranged_weapon.name);
                    FPSPlayerPrefab.GetComponent<Shooter>().projectileDamage += 8;
                    FPSPlayerPrefab.GetComponent<Shooter>().projectileCount += 1;
                }
                else if (ranged_weapon.name == "Pen") {
                    print("weapon: " + ranged_weapon.name);
                    FPSPlayerPrefab.GetComponent<Shooter>().projectileDamage += 1;
                    FPSPlayerPrefab.GetComponent<Shooter>().projectileCount += 8;
                }
                else if (ranged_weapon.name == "Keyboard") {
                    print("weapon: " + ranged_weapon.name);
                    FPSPlayerPrefab.GetComponent<Shooter>().projectileDamage += 3;
                    FPSPlayerPrefab.GetComponent<Shooter>().projectileCount += 4;
                }

                //melee weapons
                // if (melee_weapon.name == "Mop") {
                //     print("weapon: " + melee_weapon.name);
                //     FPSPlayerPrefab.GetComponent<Meleer>().hitDamage += 5;
                // }
                // else if (melee_weapon.name == "HDMI Weapon") {
                //     print("weapon: " + melee_weapon.name);
                //     FPSPlayerPrefab.GetComponent<Meleer>().hitDamage += 3;
                // }

                timesPressed += 1;
                //currently allows for one boost per round
            }
        }
    }
}
