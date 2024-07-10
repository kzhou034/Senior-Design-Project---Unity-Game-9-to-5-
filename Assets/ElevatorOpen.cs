using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorOpen : MonoBehaviour
{
    [SerializeField] Transform Left;
    [SerializeField] Transform Right;
    [SerializeField] Spawner spawn;
    [SerializeField] Camera cam;
    float t = 0f;
    Vector3 l_start;
    Vector3 r_start;
    Vector3 l_end;
    Vector3 r_end;
    public bool closing;
    bool opened;
    // Start is called before the first frame update
    void Start()
    {
        opened = false;
        closing = false;
        l_start = Left.position;
        r_start = Right.position;
        l_end = Left.position-new Vector3(0,0,0.8f);
        r_end = Right.position+new Vector3(0,0,0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Elevator" && !opened && t < 1){
            Left.position = Vector3.Lerp(l_start,l_end,t);
            Right.position = Vector3.Lerp(r_start,r_end,t);
            t += .01f;
        }
        if(SceneManager.GetActiveScene().name != "Elevator" && closing && spawn.isDone && t < 1){
            Left.position = Vector3.Lerp(l_end,l_start,t);
            Right.position = Vector3.Lerp(r_end,r_start,t);
            t += .01f;
        }
        if(t>=1){
            if(closing){
                cam.GetComponent<MapHandler>().nextMap();
            }
            opened = true;
            t = 0;
        }
        if(closing && SceneManager.GetActiveScene().name == "Elevator"){
            cam.GetComponent<MapHandler>().nextMap();
        }
    }
}
