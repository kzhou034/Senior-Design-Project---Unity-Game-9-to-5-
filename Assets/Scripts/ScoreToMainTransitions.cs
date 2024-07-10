using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreToMainTransition : MonoBehaviour
{
    public void ToMainMenu() {
        Debug.Log("is clicked");
        SceneManager.LoadScene("Scenes/Start Menu");
    }
}
