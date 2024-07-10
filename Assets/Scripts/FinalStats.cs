using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalStats : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Score: " + PlayerPrefs.GetInt("score");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}