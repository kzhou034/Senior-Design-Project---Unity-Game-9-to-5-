using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassiveAbilities : MonoBehaviour
{
    //#[SerializeField] GameObject _object;
    public TextMeshProUGUI healthText;
    PlayerMovement pm, pmj;
    PlayerHealth ph;

    // Start is called before the first frame update
    void Start()
    {
        pm =  transform.GetComponent<PlayerMovement>();
        pmj =  transform.GetComponent<PlayerMovement>();
        ph =  transform.GetComponent<PlayerHealth>();
    }

    //updates every frame
    void Update() {
    }

    public void IncreaseSpeed(float amount) {
        pm.speed = amount;
        PlayerPrefs.SetFloat("speed", amount);
    }
    public void IncreaseJump(float amount) {
        pm.jumpHeight = amount;
        PlayerPrefs.SetFloat("jump", amount);
    }
    public void IncreaseHealth(float amount) {
        ph.health = amount;
        PlayerPrefs.SetFloat("health", amount);
        healthText.text = "Health: " + ph.health;
    }
}
