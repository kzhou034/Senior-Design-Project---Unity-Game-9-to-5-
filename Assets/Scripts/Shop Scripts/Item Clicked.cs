using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ItemClicked : MonoBehaviour
{
    [Header ("General fields")]
    [SerializeField] Transform configurations;
    [SerializeField] GameObject _object;
    [SerializeField] float price;
    [SerializeField] Transform buyButton;
    [SerializeField] pickUpGun pickUp;
    [SerializeField] int weaponNumber;

    [Header ("Used to Determine melee, ranged, or ability")]
    [SerializeField] bool isWeapon;
    [SerializeField] bool isRanged; //Only used in this script

    [Header ("Only for weapons")]
    [SerializeField] string weaponName;

    [Header ("Only for abilities")]
    [SerializeField] string functionName;
    [SerializeField] float amount;

    [Header ("Only for weapon Upgrades")]
    [SerializeField] Transform slot;
    [SerializeField] Transform buttons;
    // Start is called before the first frame update
    void Start()
    {
        _object.SetActive(false); //program just started, item shouldn't be open
        if(pickUp?.weaponWheel[weaponNumber] == true){
            transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Purchased";
            transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(1,0,0);
            transform.GetComponent<Button>().enabled = false;
            return;
        }
    }

    public void RangedStats(string name){
        _object.transform.Find("Stats").GetComponent<TextMeshProUGUI>().text = 
        "Reload Time: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().reloadTime + "\n" +
        "Projectile Speed: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileSpeed + "\n" +
        "Projectile Count: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileCount + "\n" +
        "Projectile Momentum: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileMomentum + "\n" +
        "Projectile Spread: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileSpread + "\n" +
        "Projectile Damage: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileDamage + "\n" +
        "Projectile AOE: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().projectileAOE;
    }

    public void MeleeStats(string name){
        _object.transform.Find("Stats").GetComponent<TextMeshProUGUI>().text = 
        "Hit Momentum: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().hitMomentum + "\n" +
        "Hit Damage: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().hitDamage + "\n" +
        "Cooldown Time: " + configurations.Find(name).transform.GetComponent<WeaponConfigs>().cooldownTime;
    }

    //taken from shop.cs
    public void Select() {
        _object.transform.Find("Slots").gameObject.SetActive(false);
        _object.transform.Find("Buttons").gameObject.SetActive(false);
        _object.transform.Find("Stats").gameObject.SetActive(true);
        _object.transform.Find("Price Text").GetComponent<Prices>().weaponPrice = price;
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+price.ToString();
        _object.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = transform.name;
        _object.transform.Find("Price Text").GetComponent<Prices>().weaponName = transform.name;
        buyButton.GetComponent<BuyButton>().upgrading = false;
        if(isWeapon){
            _object.transform.Find("Sprite").gameObject.SetActive(true);
            if(isRanged){
                RangedStats(transform.name);
            }
            else{
                MeleeStats(transform.name);
            }
        }
        else{
            _object.transform.Find("Sprite").gameObject.SetActive(false);
            _object.transform.Find("Stats").GetComponent<TextMeshProUGUI>().text = "";
        }
        _object.SetActive(true);
        buyButton.GetComponent<BuyButton>().price = price;
        buyButton.GetComponent<BuyButton>().weaponName = weaponName;
        buyButton.GetComponent<BuyButton>().isWeapon = isWeapon;
        buyButton.GetComponent<BuyButton>().functionName = functionName;
        buyButton.GetComponent<BuyButton>().shopLabel = transform;
        buyButton.GetComponent<BuyButton>().amount = amount;
    }

    public void upgradeSelect(){
        _object.SetActive(true);
        _object.transform.Find("Slots").gameObject.SetActive(true);
        _object.transform.Find("Buttons").gameObject.SetActive(true);
        _object.transform.Find("Sprite").gameObject.SetActive(false);
        _object.transform.Find("Stats").gameObject.SetActive(false);
        _object.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = weaponName;
        _object.transform.Find("Price Text").GetComponent<Prices>().activeName = weaponName;
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        buttons.GetComponent<Upgrade>().upgradeName = weaponName;
        buyButton.GetComponent<BuyButton>().shopLabel = transform;
        buyButton.GetComponent<BuyButton>().upgrading = true;
        if(isRanged){
            buttons.Find("Ranged Increase").gameObject.SetActive(true);
            buttons.Find("Melee Increase").gameObject.SetActive(false);
            buttons.Find("Ranged Decrease").gameObject.SetActive(true);
            buttons.Find("Melee Decrease").gameObject.SetActive(false);
            slot.Find("Slot 1").GetComponent<TextMeshProUGUI>().text = "Reload Time: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().reloadTime + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().reloadTime-transform.GetComponent<WeaponConfigs>().reloadTime);
            slot.Find("Slot 2").GetComponent<TextMeshProUGUI>().text = "Projectile Speed: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileSpeed + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileSpeed+transform.GetComponent<WeaponConfigs>().projectileSpeed);
            slot.Find("Slot 3").GetComponent<TextMeshProUGUI>().text = "Projectile Count: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileCount + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileCount+transform.GetComponent<WeaponConfigs>().projectileCount);
            slot.Find("Slot 4").GetComponent<TextMeshProUGUI>().text = "Projectile Spread: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileSpread + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileSpread-transform.GetComponent<WeaponConfigs>().projectileSpread);
            slot.Find("Slot 5").GetComponent<TextMeshProUGUI>().text = "Projectile Momentum: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileMomentum + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileMomentum+transform.GetComponent<WeaponConfigs>().projectileMomentum);
            slot.Find("Slot 6").GetComponent<TextMeshProUGUI>().text = "Projectile Damage: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileDamage + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileDamage+transform.GetComponent<WeaponConfigs>().projectileDamage);
            slot.Find("Slot 7").GetComponent<TextMeshProUGUI>().text = "Projectile AOE: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileAOE + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().projectileAOE+transform.GetComponent<WeaponConfigs>().projectileAOE);
            slot.Find("Slot 4").gameObject.SetActive(true);
            slot.Find("Slot 5").gameObject.SetActive(true);
            slot.Find("Slot 6").gameObject.SetActive(true);
            slot.Find("Slot 7").gameObject.SetActive(true);
        }
        else{
            buttons.Find("Ranged Increase").gameObject.SetActive(false);
            buttons.Find("Melee Increase").gameObject.SetActive(true);
            buttons.Find("Ranged Decrease").gameObject.SetActive(false);
            buttons.Find("Melee Decrease").gameObject.SetActive(true);
            slot.Find("Slot 1").GetComponent<TextMeshProUGUI>().text = "Cooldown Time: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().cooldownTime + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().cooldownTime-transform.GetComponent<WeaponConfigs>().cooldownTime);
            slot.Find("Slot 2").GetComponent<TextMeshProUGUI>().text = "Hit Momentum: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().hitMomentum + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().hitMomentum+transform.GetComponent<WeaponConfigs>().hitMomentum);
            slot.Find("Slot 3").GetComponent<TextMeshProUGUI>().text = "Hit Damage: "+configurations.Find(weaponName).GetComponent<WeaponConfigs>().hitDamage + " -> " + (configurations.Find(weaponName).GetComponent<WeaponConfigs>().hitDamage+transform.GetComponent<WeaponConfigs>().hitDamage);;
            slot.Find("Slot 4").gameObject.SetActive(false);
            slot.Find("Slot 5").gameObject.SetActive(false);
            slot.Find("Slot 6").gameObject.SetActive(false);
            slot.Find("Slot 7").gameObject.SetActive(false);
        }
    }

    private void OnDisable(){
        transform.GetComponent<Button>().onClick.RemoveAllListeners();
    }

}
