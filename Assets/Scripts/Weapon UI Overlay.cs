using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics.Tracing;

public class WeaponUIOverlay : MonoBehaviour
{
    public string[] weaponNames = {"Stapler","Pen","Keyboard","Projector","HDMI","Mop"};
    public Image[] weaponSlotImages; 
    public string[] imagePathsLocked;   
    public string[] imagePathsUnequipped;   
    public string[] imagePathsEquipped;   
    public pickUpGun puGun;
    
    void Start()
    {

        if (weaponSlotImages.Length != imagePathsLocked.Length)
        {
            //Debug.LogError("Error - number of image components and links doesn't match!");
            return;
        }

        for (int i = 0; i < imagePathsLocked.Length; i++)
        {
            LoadAndSetImage(imagePathsLocked[i], weaponSlotImages[i]);
        }

        //Debug.Log(puGun.weaponWheel.Length);
    }

    public void LoadAndSetImage(string path, Image imageComponent)
    {
        if (!File.Exists(Path.Combine(Application.dataPath, path)))
        {
            //Debug.LogError($"Image file not found: {path}");
            return;
        }

        // Load the image data from the file
        byte[] imageData = File.ReadAllBytes(Path.Combine(Application.dataPath, path));

        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageData);

        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        imageComponent.sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("weapon equipped is " + puGun.currentWeapon);
        for (int i = 0; i < puGun.weaponWheel.Length; i++) {
            if (puGun.weaponWheel[i]) {
                //Debug.Log("Weapon name in script is "+weaponNames[i]+", current weapon label is "+ puGun.currentWeapon); 
                if (i == PlayerPrefs.GetInt("currWeapon")) { 
                    LoadAndSetImage(imagePathsEquipped[i], weaponSlotImages[i]);
                }
                else {
                    LoadAndSetImage(imagePathsUnequipped[i], weaponSlotImages[i]);
                }
            }
        }
        
    }
}
