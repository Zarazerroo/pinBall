using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Text LivesText;
    [SerializeField] private GameObject ballPrefab;
    public Vector3 ballRespawnPosition; 

    public int lives = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RespawnBall()
    {
        Instantiate(ballPrefab, ballRespawnPosition, quaternion.identity);
    }

    public void spawnSmallerBalls(Vector3 spawnLocation ,int ballsCount ,GameObject ball)
    {
        Destroy(ball);
        for (int i = 0; i <= ballsCount; i++)
        { 
            var smallBall = Instantiate(ballPrefab, spawnLocation, quaternion.identity);
            ball.transform.localScale *= .25f;
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f,2f));
        }

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