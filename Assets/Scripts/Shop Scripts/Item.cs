using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        yourButton.onClick.AddListener(TaskOnClick);
        print("test");
    }

    void TaskOnClick(){
		print("You have clicked the button!");
	}
}
