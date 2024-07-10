using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchTabs : MonoBehaviour
{
    [SerializeField] GameObject weaponsTab;
    [SerializeField] Button weaponsBtn;
    [SerializeField] GameObject upgradesTab;
    [SerializeField] Button upgradesBtn;
    [SerializeField] GameObject _object;
    [SerializeField] Transform buyButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor(Button btn, Color color){
        ColorBlock cb = btn.colors;
        cb.normalColor = color;
        cb.highlightedColor = color;
        cb.pressedColor = color;
        cb.selectedColor = color;
        btn.colors = cb;
    }

    public void ToUpgrades(){
        buyButton.GetComponent<BuyButton>().upgrading = true;
        _object.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = _object.transform.Find("Price Text").GetComponent<Prices>().activeName;
        _object.transform.Find("Slots").gameObject.SetActive(true);
        _object.transform.Find("Buttons").gameObject.SetActive(true);
        _object.transform.Find("Sprite").gameObject.SetActive(false);
        _object.transform.Find("Stats").gameObject.SetActive(false);
        changeColor(upgradesBtn, new Color(.75f,.75f,.75f));
        changeColor(weaponsBtn, new Color(1,1,1));
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().getUpgradePrice();
        weaponsTab.SetActive(false);
        upgradesTab.SetActive(true);
    }

    public void ToWeapons(){
        buyButton.GetComponent<BuyButton>().upgrading = false;
        _object.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = _object.transform.Find("Price Text").GetComponent<Prices>().weaponName;
        _object.transform.Find("Slots").gameObject.SetActive(false);
        _object.transform.Find("Buttons").gameObject.SetActive(false);
        _object.transform.Find("Stats").gameObject.SetActive(true);
        changeColor(weaponsBtn, new Color(.75f,.75f,.75f));
        changeColor(upgradesBtn, new Color(1,1,1));
        _object.transform.Find("Price Text").GetComponent<TextMeshProUGUI>().text = "price: "+_object.transform.Find("Price Text").GetComponent<Prices>().weaponPrice;
        upgradesTab.SetActive(false);
        weaponsTab.SetActive(true);
    }
}
