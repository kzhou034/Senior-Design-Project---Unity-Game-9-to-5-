using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    [Header ("General fields")]
    public float price;
    [SerializeField] Transform player;
    [SerializeField] PassiveAbilities passiveAbilitiesFunctions;
    [SerializeField] Upgrade upgradeBtn;
    [SerializeField] pickUpGun inventory;
    public Transform shopLabel;
    [SerializeField] GameObject _object;

    [Header ("Used to Determine weapon or ability")]
    public bool isWeapon;

    [Header ("Only for weapons")]
    public string weaponName;

    [Header ("Only for abilities")]
    public string functionName;
    public float amount;

    [Header ("Only for upgrades")]
    public bool upgrading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy(){
        if(player.GetComponent<PlayerMoney>().cash >= price && !upgrading && shopLabel.GetComponent<Button>().enabled){
            player.GetComponent<PlayerMoney>().AddCash(-price);
            _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+0;
            _object.transform.Find("Price Text").GetComponent<Prices>().weaponPrice = 0;
            shopLabel.GetComponent<Button>().enabled = false;
            shopLabel.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Purchased";
            shopLabel.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().color = new Color(1,0,0);
            if(isWeapon){
                inventory.pickUp(weaponName);
            }
            else if(!isWeapon){
                if(functionName == "IncreaseHealth"){
                    passiveAbilitiesFunctions.IncreaseHealth(amount);
                }
                else if(functionName == "IncreaseSpeed"){
                    passiveAbilitiesFunctions.IncreaseSpeed(amount);
                }
                else if(functionName == "IncreaseJump"){
                    passiveAbilitiesFunctions.IncreaseJump(amount);
                }
            }
        }
        else if(upgrading){
            upgradeBtn.Apply();
        }
    }
}
