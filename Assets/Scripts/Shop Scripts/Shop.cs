using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    [SerializeField] GameObject _object;
    [SerializeField] GameObject main_cam;
    [SerializeField] Use_Computer computer;

    //initialization
    void Start() {
        print("shop initialization");
        _object.SetActive(false); //program just started, shop shouldn't be open
        Cursor.visible = false; //don't show cursor if shop isn't open
    }
    
    //updates every frame
    bool shop_overlay_status = false;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            //if tab pressed, open or close the shop overlay
            userToggle();
        }
        
        if(shop_overlay_status == false) {
            //shop closed - hide cursor
            Cursor.visible = false;
            //cursor locked to center
            Cursor.lockState = CursorLockMode.Locked; 
            
        }
        else {
            //shop opened - show cursor
            Cursor.visible = true;
            //cursor moves freely within the game window
            Cursor.lockState = CursorLockMode.Confined; 

        }
    }

    public void userToggle() {
        bool currState = _object.activeSelf; //gets t/f statement
        //t = shop is showing, f = not showing
        if (currState == false) {
            //not showing, but want it to show up
            _object.SetActive(true);
            shop_overlay_status = true;    
            main_cam.GetComponent<MouseLook>().enabled = false;
            computer.enabled = false;
        }
        else {
            //is showing, but want it to close
            _object.SetActive(false);
            shop_overlay_status = false;
            main_cam.GetComponent<MouseLook>().enabled = true;
            computer.enabled = true;
        }

    }
}


