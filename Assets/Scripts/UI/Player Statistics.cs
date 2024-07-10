using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatistics : MonoBehaviour
{
    public int score;
    public int enemyKillCount;
    public int meleeKillCount;
    public int shooterKillCount;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if(PlayerPrefs.HasKey("score")){
            Debug.Log("score test: " + score);
            score = PlayerPrefs.GetInt("score");
        }
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(int scoreVal = 10, string enemyType = "enemy")
    {
        score += scoreVal;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = "Score: " + score.ToString();
        if (enemyType == "melee") {
            meleeKillCount += 1;
        }
        else if (enemyType == "shooter") {
            shooterKillCount += 1;
        }
        else {
            enemyKillCount += 1;
        }
    }
}
//work pls