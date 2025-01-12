using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Text LivesText;
    [SerializeField] private GameObject ballPrefab;
    public Vector3 ballRespawnPosition; 
    //public int lives = 3;
    public ScoreKeeper score; 
    public int ballsCount = 1 ; 
    public void RespawnBall()
    {
        score = FindAnyObjectByType<ScoreKeeper>();
        Instantiate(ballPrefab, ballRespawnPosition, quaternion.identity);
    }
    
    public void DestroyBall(GameObject ball)
    {
        
        ballsCount--;
        Destroy(ball);
        //lives--;
        //LivesText.text = lives.ToString();
        if (ballsCount < 0)
            score.ResetScore();
            
    }
}