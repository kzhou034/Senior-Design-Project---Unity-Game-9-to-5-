using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public float cash;
    public TextMeshProUGUI cashText;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("cash")){
            cash = PlayerPrefs.GetFloat("cash");
            Debug.Log("hit get float cash + " + cash);
        }
        cashText.text = "$" + cash.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCash(float value = 10)
    {
        cash += value;
        PlayerPrefs.SetFloat("cash", cash);
        cashText.text = "$" + cash.ToString();
        Debug.Log("hit add cash + " + cash);
        
    }
}
//work pls