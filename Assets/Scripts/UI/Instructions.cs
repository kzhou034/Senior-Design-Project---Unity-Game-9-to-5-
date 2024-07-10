using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Instructions : MonoBehaviour
{
    [SerializeField] GameObject _object;
    [SerializeField] GameObject main_cam;
    [SerializeField] Use_Computer computer;

    //initialization
    void Start() {
        int i = 0;
        Cursor.visible = false; //don't show cursor if shop isn't open
        print("instructions initialization");
        if (PlayerPrefs.HasKey("i")){
            i = PlayerPrefs.GetInt("i");
        }
        if (i == 0){
            _object.SetActive(true); //program just started, instructions should be open
        }
        else{
            _object.SetActive(false);
        }
    }
    
    //updates every frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //if tab pressed, open or close the shop overlay
            Toggle();
        }
    }

    public void Toggle() {
        bool currState = _object.activeSelf; //gets t/f statement
        //t = shop is showing, f = not showing
        if (currState == false) {
        }
        else {
            //is showing, but want it to close
            _object.SetActive(false);
            main_cam.GetComponent<MouseLook>().enabled = true;
            computer.enabled = true;
        }

    }
}


