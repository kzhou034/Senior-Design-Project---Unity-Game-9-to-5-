using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public string upgradeName;
    [SerializeField] Transform slot;
    [SerializeField] Transform weaponConfig;
    [SerializeField] GameObject _object;
    [SerializeField] Transform player;
    [SerializeField] Transform list;
    [SerializeField] Shooter gunscript;
    [SerializeField] Meleer melee; 
    [SerializeField] pickUpGun pick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadUpgrade(float amount){
        if(weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime - (list.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime + amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime += amount;
            slot.Find("Slot 1").GetComponent<TextMeshProUGUI>().text = 
            "Reload Time: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime-list.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime);
        }
    }

    public void ReloadDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime -= amount;
            slot.Find("Slot 1").GetComponent<TextMeshProUGUI>().text = 
            "Reload Time: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime-list.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime);
        }
    }

    public void SpeedUpgrade(float amount){
        _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed += amount;
        slot.Find("Slot 2").GetComponent<TextMeshProUGUI>().text = 
        "Projectile Speed: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed);
    }

    public void SpeedDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed -= amount;
            slot.Find("Slot 2").GetComponent<TextMeshProUGUI>().text = 
            "Projectile Speed: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed);
        }
    }

    public void CountUpgrade(int amount){
        _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount += amount;
        slot.Find("Slot 3").GetComponent<TextMeshProUGUI>().text = 
        "Projectile Count: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount);
    }

    public void CountDecrease(int amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount -= amount;
            slot.Find("Slot 3").GetComponent<TextMeshProUGUI>().text = 
            "Projectile Count: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount);
        }
    }

    public void SpreadUpgrade(float amount){
        if(weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread - (list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread + amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread += amount;
            slot.Find("Slot 4").GetComponent<TextMeshProUGUI>().text = 
            "Projectile Spread: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread-list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread);
        }
    }

    public void SpreadDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread -= amount;
            slot.Find("Slot 4").GetComponent<TextMeshProUGUI>().text = 
            "Projectile Spread: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread);
        }
    }

    public void MomentumUpgrade(float amount){
        _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum += amount;
        slot.Find("Slot 5").GetComponent<TextMeshProUGUI>().text = 
        "Projectile Momentum: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum);
    }

    public void MomentumDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum -= amount;
            slot.Find("Slot 5").GetComponent<TextMeshProUGUI>().text = 
            "Projectile Momentum: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum);
        }
    }

    public void DamageUpgrade(float amount){
        _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage += amount;
        slot.Find("Slot 6").GetComponent<TextMeshProUGUI>().text = 
        "Projectile Damage: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage);
    }

    public void DamageDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage -= amount;
            slot.Find("Slot 6").GetComponent<TextMeshProUGUI>().text = 
            "Projectile Damage: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage);
        }
    }

    public void AOEUpgrade(float amount){
        _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE += amount;
        slot.Find("Slot 7").GetComponent<TextMeshProUGUI>().text = 
        "Projectile AOE: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE+list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE);
    }

    public void AOEDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE -= amount;
            slot.Find("Slot 7").GetComponent<TextMeshProUGUI>().text = 
            "Projectile AOE: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE-list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE);
        }
    }

    public void CooldownUpgrade(float amount){
        if(weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime - (list.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime + amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime += amount;
            slot.Find("Slot 1").GetComponent<TextMeshProUGUI>().text = 
            "Cooldown Time: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime-list.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime);
        }
    }

    public void CooldownDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime -= amount;
            slot.Find("Slot 1").GetComponent<TextMeshProUGUI>().text = 
            "Cooldown Time: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime-list.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime);
        }
    }

    public void HitMomentumUpgrade(float amount){
        _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        list.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum += amount;
        slot.Find("Slot 2").GetComponent<TextMeshProUGUI>().text = 
        "Hit Momentum: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum+list.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum);
    }

    public void HitMomentumDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum -= amount;
            slot.Find("Slot 2").GetComponent<TextMeshProUGUI>().text = 
            "Hit Momentum: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum+list.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum);
        }
    }

    public void HitDamageUpgrade(float amount){
        _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(25);
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        list.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage += amount;
        slot.Find("Slot 3").GetComponent<TextMeshProUGUI>().text = 
        "Hit Damage: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage+list.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage);
    }

    public void HitDamageDecrease(float amount){
        if((list.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage - amount) >= 0){
            _object.transform.Find("Price Text").GetComponent<Prices>().AddUpgradePrice(-25);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
            list.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage -= amount;
            slot.Find("Slot 3").GetComponent<TextMeshProUGUI>().text = 
            "Hit Damage: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage + " -> " + (weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage+list.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage);
        }
    }

    public void Apply(){
        if(_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice() != 0  && player.GetComponent<PlayerMoney>().cash >= _object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice()){
            player.GetComponent<PlayerMoney>().AddCash(-(_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice()));
            
            if(upgradeName != "Mop" && upgradeName != "HDMI"){
                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime -= list.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime;
                slot.Find("Slot 1").GetComponent<TextMeshProUGUI>().text = 
                "Reload Time: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"ReloadTime");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"ReloadTime", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime);

                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed += list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed;
                slot.Find("Slot 2").GetComponent<TextMeshProUGUI>().text = 
                "Projectile Speed: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"ProjectileSpeed");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"ProjectileSpeed", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed);

                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount += list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount;
                slot.Find("Slot 3").GetComponent<TextMeshProUGUI>().text = 
                "Projectile Count: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"ProjectileCount");
                PlayerPrefs.SetInt(list.Find(upgradeName).name+"ProjectileCount", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount);

                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread -= list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread;
                slot.Find("Slot 4").GetComponent<TextMeshProUGUI>().text = 
                "Projectile Spread: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"ProjectileSpread");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"ProjectileSpread", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread);

                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum += list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum;
                slot.Find("Slot 5").GetComponent<TextMeshProUGUI>().text = 
                "Projectile Momentum: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"ProjectileMomentum");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"ProjectileMomentum", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum);

                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage += list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage;
                slot.Find("Slot 6").GetComponent<TextMeshProUGUI>().text = 
                "Projectile Damage: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"ProjectileDamage");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"ProjectileDamage", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage);

                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE += list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE;
                slot.Find("Slot 7").GetComponent<TextMeshProUGUI>().text = 
                "Projectile AOE: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"ProjectileAOE");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"ProjectileAOE", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE);

            }
            else{
                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime -= list.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime;
                slot.Find("Slot 1").GetComponent<TextMeshProUGUI>().text = 
                "Cooldown Time: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"CooldownTime");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"CooldownTime", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime);

                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum += list.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum;
                slot.Find("Slot 2").GetComponent<TextMeshProUGUI>().text = 
                "Hit Momentum: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"HitMomentum");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"HitMomentum", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum);

                weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage += list.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage;
                slot.Find("Slot 3").GetComponent<TextMeshProUGUI>().text = 
                "Hit Damage: "+weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage;
                //store across scenes
                Debug.Log(list.Find(upgradeName).name+"HitDamage");
                PlayerPrefs.SetFloat(list.Find(upgradeName).name+"HitDamage", weaponConfig.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage);
            }

            list.Find(upgradeName).GetComponent<WeaponConfigs>().reloadTime = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpeed = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileCount = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileSpread = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileMomentum = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileDamage = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().projectileAOE = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().cooldownTime = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().hitMomentum = 0;
            list.Find(upgradeName).GetComponent<WeaponConfigs>().hitDamage = 0;


            _object.transform.Find("Price Text").GetComponent<Prices>().SetUpgradePrice(0);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+0;
            if(pick.currentWeapon == upgradeName){
                if(melee.enabled){
                    pick.configurateMeleeWeapon(pick.currentWeapon);
                    melee.RegenerateWeapon();
                }
                if(gunscript.enabled){
                    pick.configurateRangedWeapon(pick.currentWeapon);
                    gunscript.RegenerateWeapon();
                }
            }
        }
    }
}
