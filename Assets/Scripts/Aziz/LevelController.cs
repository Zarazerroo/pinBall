using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Text LivesText;
    [SerializeField] private GameObject ballPrefab;
    public Vector3 ballRespawnPosition; 
    public int lives = 3;
    public void RespawnBall()
    {
        Instantiate(ballPrefab, ballRespawnPosition, quaternion.identity);
    }
    
    public void DestroyBall(GameObject ball)
    {
        Destroy(ball);
        lives--;
        LivesText.text = lives.ToString();
        if(lives> 0 )
            RespawnBall();
    }
}