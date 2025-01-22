using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Text leaderboardText;
    [SerializeField] private InputField userNameField; 
    [SerializeField] private Text LivesText;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Spotlight spotlightManager;

    private int lives = 3; 
    public int ballsCount = 1;
    private Leaderboard leaderboard; 
    private Vector3 ballRespawnPosition;
    private ScoreKeeper score;
    private bool gamePaused = true ; 
    private string userName;
    private Vector2 initalSpawnPos = new Vector2(-78.5f, 9);
    
    public void Start()
    {
        score = FindAnyObjectByType<ScoreKeeper>();
        leaderboard = FindAnyObjectByType<Leaderboard>();
        PauseGame();
    }
    
    public void RespawnBall()
    {
        Instantiate(ballPrefab, initalSpawnPos, quaternion.identity);
        Debug.LogWarning($"Balls count at respawn{ballsCount}");
    }

    public void DestroyBall(GameObject ball)
    {
        
        lives--;
        Destroy(ball);
        if (lives > 0)
        {
            RespawnBall();
        }

        switch (lives)
        {
            case 3 :
                spotlightManager.WarningFlash(Color.blue); 
                break;
            case 2 :
                spotlightManager.WarningFlash(Color.yellow); 
                break;
            case 1 : 
                spotlightManager.WarningFlash(Color.red);
                break;
        }
        if(lives == 0 )
        {
            leaderboard.SaveScore(score.score,userName);
            PauseGame();
            score.ResetScore();
        }
    }

    public void PauseGame()
    {
        leaderboardText.text = leaderboard.getLeaderBoard();
        gamePaused = true;
        pauseScreen.GetComponent<SpriteRenderer>().enabled = true; 
        pauseScreen.GetComponentInChildren<Canvas>().enabled = true; 
        pauseScreen.GetComponentInChildren<Text>().enabled = true; 
    }

    public void StartGame()
    {
        lives = 3; 
        RespawnBall();
        gamePaused = false;
        pauseScreen.GetComponent<SpriteRenderer>().enabled = false;
        pauseScreen.GetComponentInChildren<Canvas>().enabled = false;
        pauseScreen.GetComponentInChildren<Text>().enabled = false; 
        userName = userNameField.text; 
    }
}