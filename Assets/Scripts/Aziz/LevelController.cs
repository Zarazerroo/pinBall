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
        Destroy(ball); 
        leaderboard.SaveScore(score.score,userName);
        PauseGame();
        score.ResetScore();
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
        RespawnBall();
        gamePaused = false;
        pauseScreen.GetComponent<SpriteRenderer>().enabled = false;
        pauseScreen.GetComponentInChildren<Canvas>().enabled = false;
        pauseScreen.GetComponentInChildren<Text>().enabled = false; 
        userName = userNameField.text; 
    }
}