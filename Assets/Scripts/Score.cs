using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static Score instance;
    public Text scoreText;
    public int score = 0; 
    public int highScore = 0;
    void Start()
    {
        updateScoreDisplay();
    }

    public void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore()
    {
        score++;
        updateScoreDisplay();
    }
    public void resetScore()
    {
        updateHighScore();
        score = 0;
        Time.timeScale = 0;
        StartCoroutine(ResetGame());
        
    }

    public void updateHighScore()
    { 
        if(score > highScore)
        {
            highScore = score;
        } 
        
    }
    public void updateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString() + "\n Highscore: " + highScore.ToString();
 
    }
    
    IEnumerator ResetGame()
    {
        yield return new WaitForSecondsRealtime(1); 
        Time.timeScale = 1;
        Ball.instance.Reset();
        MouseMovement.instance.Reset();
        updateScoreDisplay();
    }
}
