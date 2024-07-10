using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game2 : MonoBehaviour
{
    [SerializeField] Transform Player; //RC Player
    [SerializeField] GameObject cam;   //RC Camera
    [SerializeField] GameObject Object;
    [SerializeField] LayerMask layer;
    [SerializeField] Transform FPSPlayer;
    [SerializeField] Vector3 RCPosition;
    bool playing = false;
    string[] targets = {"Computers","Mugs","Pens","Keyboards","Chairs","Water Coolers","Couches","Staplers"};
    string target;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game"){
            targets[7] = "Computers";
        }
        else if(SceneManager.GetActiveScene().name == "Game - PremiumMap"){
            targets[1] = "Staplers";
            targets[5] = "Computers";
            targets[6] = "Chairs";
        }
        else if(SceneManager.GetActiveScene().name == "Game - CubicleMap"){
            targets[1] = "Staplers";
            targets[5] = "Computers";
            targets[6] = "Chairs";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Fire2")){
            Cursor.visible = true;
            if(Cursor.lockState == CursorLockMode.None){
                Cursor.lockState = CursorLockMode.Locked;
                cam.GetComponent<MouseLook>().enabled = true;
            }
            else{
                Cursor.lockState = CursorLockMode.None;
                cam.GetComponent<MouseLook>().enabled = false;
            }
        }
        if(playing){
            RaycastHit hit;
            Physics.Raycast(cam.transform.position + new Vector3(0, .75f, 0), cam.transform.forward, out hit, 3, ~layer);
            if(hit.collider?.transform.parent?.name == target){
                FPSPlayer.GetComponent<PlayerMoney>().AddCash(10);
                changeTarget();
            }
        }
    }

    void FixedUpdate()
    {
        if(!playing){
            Player.position = RCPosition;
            Player.rotation = Quaternion.identity;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
            cam.GetComponent<MouseLook>().enabled = true;
            changeTarget();
            playing = true;
        }
    }

    public void Reset(){
        changeTarget();
        playing = false;
    }

    void changeTarget(){
        target = targets[Random.Range(0,targets.Length)];
        Object.GetComponent<Text>().text = target;
    }

}
