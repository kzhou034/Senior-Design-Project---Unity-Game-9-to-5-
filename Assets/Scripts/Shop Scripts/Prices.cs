using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prices : MonoBehaviour
{
    public string weaponName;
    public float weaponPrice;

    public string activeName;
    public float staplerPrice;
    public float penPrice;
    public float mopPrice;
    public float keyboardPrice;
    public float hdmiPrice;
    public float projectorPrice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getUpgradePrice(){
        if(activeName == "Stapler"){return staplerPrice;}
        else if(activeName == "Pen"){return penPrice;}
        else if(activeName == "Mop"){return mopPrice;}
        else if(activeName == "Keyboard"){return keyboardPrice;}
        else if(activeName == "HDMI"){return hdmiPrice;}
        else if(activeName == "Projector"){return projectorPrice;}
        return 0;
    }

    public void SetUpgradePrice(float price){
        if(activeName == "Stapler"){staplerPrice = price;}
        else if(activeName == "Pen"){penPrice = price;}
        else if(activeName == "Mop"){mopPrice = price;}
        else if(activeName == "Keyboard"){keyboardPrice = price;}
        else if(activeName == "HDMI"){hdmiPrice = price;}
        else if(activeName == "Projector"){projectorPrice = price;}
    }

    public void AddUpgradePrice(float price){
        if(activeName == "Stapler"){staplerPrice += price;}
        else if(activeName == "Pen"){penPrice += price;}
        else if(activeName == "Mop"){mopPrice += price;}
        else if(activeName == "Keyboard"){keyboardPrice += price;}
        else if(activeName == "HDMI"){hdmiPrice += price;}
        else if(activeName == "Projector"){projectorPrice += price;}
    }
}
