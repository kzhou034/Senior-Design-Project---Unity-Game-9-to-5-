using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUIHover : MonoBehaviour
{
    public LayerMask Ignore;
    public GameObject CanvasPrefab;
    public Camera cam;
    GameObject ui;
    TMP_Text text;
    [SerializeField] Spawner spawn;
    [SerializeField] Transform enemies;
    [SerializeField] ElevatorOpen elevator;
    // Start is called before the first frame update
    public pickUpGun weaponPickUpScript;
    int i = -1;
    string[,] arr = new string[6, 6]{
        {"10", "3", "2", "15", "10", "5"}, {"10", "7", "5", "5", "15", "10"}, {"1", "1", "3", "1", "0", "0"}, {"0", "0", "6", "0", "0", "0"}, {"4", "0", "0", "1", "0", "0"}, {"1", ".25", "1", ".1", "2", "1"}
    };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Instantiate(CanvasPrefab);
        //cast a ray! if the ray hits something in the middle of the screen that's an "interactable" then we should create a new interactable so that a ui shows up
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, 3, ~Ignore)){
             //Debug.Log(hit.collider.tag);
            if ((hit.collider.tag == "stapler" || hit.collider.tag == "keyboard" || hit.collider.tag == "pen" || hit.collider.tag == "mop" || hit.collider.tag == "projector" || hit.collider.tag == "hdmi") && hit.distance <= 3.0){
                //if the item is an interactable, then we should create a new canvas so that the ui shows up
                //Debug.Log("hit!");
                if(hit.collider.tag == "stapler"){
                    i = 1;
                }
                else if (hit.collider.tag == "keyboard"){
                    i = 2;
                }
                else if (hit.collider.tag == "pen"){
                    i = 0;
                }
                else if (hit.collider.tag == "mop"){
                    i = 4;
                }
                else if (hit.collider.tag == "projector"){
                    i = 3;
                }
                else if (hit.collider.tag == "hdmi"){
                    i = 5;
                }
                if(ui == null){
                    GameObject ui2 = Instantiate(CanvasPrefab, hit.collider.gameObject.transform.position + new Vector3(0, .6f, -.2f), new Quaternion(0, -90, 0, 0), transform.Find(hit.collider.gameObject.name));
                    ui2.transform.localScale += new Vector3(.1f,.1f,.1f);
                    ui = ui2;
                    // text = ui.GetComponent<TextMeshProUGUI>();
                    var text = ui.GetComponentsInChildren<TextMeshProUGUI>();
                    foreach(TextMeshProUGUI txt in text){
                        Debug.Log(txt);
                        txt.text = char.ToUpper(hit.collider.tag[0]) + hit.collider.tag.Substring(1,hit.collider.tag.Length-1) + ": Press (E) to Pick Up\n";
                        txt.text += "Momentum: " + (string)arr[0,i] + "\n";
                        txt.text += "Damage: " + (string)arr[1,i] + "\n";
                        if(hit.collider.tag != "mop" && hit.collider.tag != "hdmi"){
                            txt.text += "Count: " + (string)arr[2,i] + "\n";
                            txt.text += "Spread: " + (string)arr[3,i] + "\n";
                            txt.text += "AOE: " + (string)arr[4,i] + "\n";
                        }
                        txt.text += "Reload Time: " + (string)arr[5,i] + "\n";
                    }
                    // Debug.Log(text);
                }
                //if E is pressed then pick up gun
                if(Input.GetKeyDown("e")) 
                {
                    Debug.Log(hit.collider.tag);
                    weaponPickUpScript.pickUp(hit.collider.tag);
                    Destroy(hit.transform.gameObject);
                }
                    
            }
            else if (hit.collider.tag == "elevator button"){
                if(Input.GetKeyDown(KeyCode.E) && (SceneManager.GetActiveScene().name == "Elevator" || (spawn.isDone && enemies.childCount == 0))){
                    elevator.closing = true;
                }
            }
        }
        else{
            if (ui != null){
                Destroy(ui);
            }
        }
    }
}
