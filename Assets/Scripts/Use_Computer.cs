using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Computer : MonoBehaviour
{
    [SerializeField] string key; //Key used to activate computer
    [SerializeField] Transform cam; //Player camera
    [SerializeField] Transform player; //The player model
    [SerializeField] float max_dist; //Max distance you can activate computer
    [SerializeField] LayerMask layer;
    [SerializeField] Transform minigames;
    [SerializeField] GameObject enemies;

    [SerializeField] Shooter gunscript;
    private bool gunActive;
    [SerializeField] Meleer melee;
    private bool meleeActive;

    bool active = false; //Is true if currently using a computer
    Transform computer; //The computer object that is used
    Vector3 pos; //Used to return camera back to original state
    float t = 0f;
    int game;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = cam.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, ~layer);
        if(!active &&
        Input.GetKeyDown(key) && 
        hit.collider?.transform.parent?.name == "Computers" &&
        Vector3.Distance(player.transform.position,hit.collider.transform.position) <= max_dist){
            cam.GetComponent<MouseLook>().enabled = false;
            cam.parent.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<MeshRenderer>().enabled = false;
            if(gunscript.enabled){gunActive = true;}
            if(melee.enabled){meleeActive = true;}
            gunscript.enabled = false;
            melee.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            active = true;
            computer = hit.collider.transform;
            t = 0;
            game = Random.Range(0,minigames.childCount);
        }
    }

    void FixedUpdate(){
        if(active){
            RaycastHit hit;
            //Checks if an object is obstructing view
            if(Physics.Raycast(computer.transform.position + new Vector3(0,.1f,0), -cam.transform.forward, out hit, 0.575f, ~layer)){
                ExitGame();
            }
            else{
                cam.transform.position = Vector3.Lerp(cam.transform.position,computer.transform.position - computer.transform.right*0.575f + computer.transform.forward*.1075f,t);
                cam.LookAt(computer.transform, computer.transform.forward);
                cam.transform.position += computer.transform.forward*.1075f;
                t += (t < 1) ? .01f : 0;
            }

            //Display minigame after camera positioned to computer
            if(t >= 1){
                minigames.position = computer.transform.position - computer.transform.right*0.21f + computer.transform.forward*.1075f;
                minigames.GetChild(game).LookAt(minigames.position + computer.transform.right, computer.transform.forward);
                minigames.GetChild(game).gameObject.SetActive(true);
                enemies.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    public void ExitGame(){
        minigames.GetChild(game).gameObject.SetActive(false);
        cam.transform.position = player.transform.position + pos;
        cam.GetComponent<MouseLook>().enabled = true;
        cam.parent.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<MeshRenderer>().enabled = true;
        gunscript.enabled = gunActive;
        melee.enabled = meleeActive;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        active = false;
        enemies.SetActive(true);
        for(int i = 0; i < enemies.transform.childCount; i++){
            enemies.transform.GetChild(i).GetComponentInChildren<Animator>()?.SetBool("Walking", true);;
        }
        t = 0;
    }

}
