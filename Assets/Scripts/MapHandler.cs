using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapHandler : MonoBehaviour
{
    string[] arr = new string[9]{"Assets/Scenes/Elevator.unity","Assets/Scenes/Game.unity", "Assets/Scenes/Elevator.unity", "Assets/Scenes/Game - PremiumMap.unity", "Assets/Scenes/Elevator.unity", "Assets/Scenes/Game - CubicleMap.unity", "Assets/Scenes/Elevator.unity", "Assets/Scenes/Game - MeetingMap.unity","Assets/Scenes/Score Screen Scene.unity"};
    int i = 0;
    public void nextMap(){
        if(PlayerPrefs.HasKey("i")){
            i = PlayerPrefs.GetInt("i");
        }
        //if i is odd then move to elevator map
        i = (i+1)%9;
        if (i < 9){
            if(i == 8){
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            PlayerPrefs.SetInt("i", i);
            Debug.Log("map handler - was clicked");
            Debug.Log(i);
            SceneManager.LoadScene(arr[i]);
        }
        else{
            //do nothing    
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        // Debug.Log(scene.name == "Game - MeetingMap");
        if((i == 7 || scene.name == "Game - MeetingMap") && GameObject.Find("spawner").GetComponent<Spawner>().isDone){
            i = 8;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerPrefs.SetInt("i", i);
            Debug.Log("map handler - meeting map call");
            Debug.Log(i);
            SceneManager.LoadScene(arr[i]);
            }

    }
}
