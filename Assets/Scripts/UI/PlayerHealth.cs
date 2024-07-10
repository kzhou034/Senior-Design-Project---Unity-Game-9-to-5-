using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //player health and armor
    public float health;
    float armor;
    public PlayerMoney money;
    //displayed health and armor using text for now
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI salaryText;
    [SerializeField] Shop shop;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        if(PlayerPrefs.HasKey("health")){
            health = PlayerPrefs.GetFloat("health");
        }
        Debug.Log("Health on startup is " + health);
        armor = 0;
        healthText.text = "Health: " + health.ToString();
        armorText.text = "Armor: " + armor.ToString();
        salaryText.text = "$" + money.cash.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //collision function
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "enemy") 
        {
            TakeDamage();
        }
    }
    
    //function used to calculate player damage
    public void TakeDamage(float attackVal = 10) 
    {
        //formula for taking damage
        float reduction = armor / 100.0f;

        attackVal -= attackVal * reduction;
        health -= attackVal;

        //updte health value on screen
        healthText.text = "Health: " + health.ToString();
        armorText.text = "Armor: " + armor.ToString();
        //check if health below 0 and if so trigger death screen
        if(health <= 0) 
        {
            // shop.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Death Screen");
        }
    }

    public void UpdateSalary(int salary) 
    {
        money.cash += salary;
        salaryText.text = "$" + money.cash.ToString();
        PlayerPrefs.SetFloat("cash", money.cash);
    }
}
