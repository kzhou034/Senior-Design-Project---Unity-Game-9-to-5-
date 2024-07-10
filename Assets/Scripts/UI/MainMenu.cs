using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //used to launch game
    public void PlayGame() {
        Debug.Log("is clicked");
        SceneManager.LoadScene("Assets/Scenes/Elevator.unity");
        if(PlayerPrefs.HasKey("i")){
            PlayerPrefs.SetInt("i", 0);
        }
        if(PlayerPrefs.HasKey("cash")){
            PlayerPrefs.SetFloat("cash", 1000);
        }
        if(PlayerPrefs.HasKey("score")){
            PlayerPrefs.SetInt("score", 0);
        }

        if(PlayerPrefs.HasKey("health")){
            PlayerPrefs.SetFloat("health", 100);
        }
        if(PlayerPrefs.HasKey("jump")){
            PlayerPrefs.SetFloat("jump", 1f);
        }
        if(PlayerPrefs.HasKey("speed")){
            PlayerPrefs.SetFloat("speed", 6f);
        }
        //stapler
        PlayerPrefs.SetInt("Stapler", 1);
        PlayerPrefs.SetFloat("StaplerReloadTime", .25f);
        PlayerPrefs.SetFloat("StaplerProjectileSpeed", 25f);
        PlayerPrefs.SetInt("StaplerProjectileCount", 1);
        PlayerPrefs.SetFloat("StaplerProjectileSpread", 0f);
        PlayerPrefs.SetFloat("StaplerProjectileMomentum", 3f);
        PlayerPrefs.SetFloat("StaplerProjectileDamage", 7f);
        PlayerPrefs.SetFloat("StaplerProjectileAOE", 0f);
        PlayerPrefs.SetFloat("StaplerProjectileLifetime", 5f);
        //pen
        PlayerPrefs.SetInt("Pen", 0);
        PlayerPrefs.SetFloat("PenReloadTime", 1f);
        PlayerPrefs.SetFloat("PenProjectileSpeed", 25f);
        PlayerPrefs.SetInt("PenProjectileCount", 1);
        PlayerPrefs.SetFloat("PenProjectileSpread", 0f);
        PlayerPrefs.SetFloat("PenProjectileMomentum", 10f);
        PlayerPrefs.SetFloat("PenProjectileDamage", 10f);
        PlayerPrefs.SetFloat("PenProjectileAOE", 4f);
        PlayerPrefs.SetFloat("PenProjectileLifetime", 5f);
        //keyboard
        PlayerPrefs.SetInt("Keyboard", 0);
        PlayerPrefs.SetFloat("KeyboardReloadTime", 1f);
        PlayerPrefs.SetFloat("KeyboardProjectileSpeed", 25f);
        PlayerPrefs.SetInt("KeyboardProjectileCount", 5);
        PlayerPrefs.SetFloat("KeyboardProjectileSpread", 6f);
        PlayerPrefs.SetFloat("KeyboardProjectileMomentum", 2f);
        PlayerPrefs.SetFloat("KeyboardProjectileDamage", 5f);
        PlayerPrefs.SetFloat("KeyboardProjectileAOE", 0f);
        PlayerPrefs.SetFloat("KeyboardProjectileLifetime", 5f);
        //projector
        PlayerPrefs.SetInt("Projector", 0);
        PlayerPrefs.SetFloat("ProjectorReloadTime", .1f);
        PlayerPrefs.SetFloat("ProjectorProjectileSpeed", 25f);
        PlayerPrefs.SetInt("ProjectorProjectileCount", 1);
        PlayerPrefs.SetFloat("ProjectorProjectileSpread", 0f);
        PlayerPrefs.SetFloat("ProjectorProjectileMomentum", 15f);
        PlayerPrefs.SetFloat("ProjectorProjectileDamage", 5f);
        PlayerPrefs.SetFloat("ProjectorProjectileAOE", 1f);
        PlayerPrefs.SetFloat("ProjectorProjectileLifetime", 5f);
        //mop
        PlayerPrefs.SetInt("Mop", 0);
        PlayerPrefs.SetFloat("MopCooldownTime", 1f);
        PlayerPrefs.SetFloat("MopHitMomentum", 5f);
        PlayerPrefs.SetFloat("MopHitDamage", 10f);
        //hdmi
        PlayerPrefs.SetInt("HDMI", 0);
        PlayerPrefs.SetFloat("HDMICooldownTime", 2f);
        PlayerPrefs.SetFloat("HDMIHitMomentum", 10f);
        PlayerPrefs.SetFloat("HDMIHitDamage", 15f);
        
        PlayerPrefs.SetInt("currWeapon", 0);
    }

    //used to open settings menu
    public void Settings() {}
    //used to quit game
    public void QuitGame() {
        Debug.Log("is clicked");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
