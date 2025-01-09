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

    public IEnumerator spawnSmallerBalls(Vector3 spawnLocation ,int ballsCount ,GameObject ball)
    {
        for (int i = 0; i <= ballsCount; i++)
        { 
            var smallBall = Instantiate(ballPrefab, spawnLocation, quaternion.identity);
            smallBall.layer = 4;
            smallBall.transform.localScale *= .4f;
            float random1 = Random.Range(-50f,50f);
            float random2 = Random.Range(-50f,50f);
            smallBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(random1*5f,random2*5f));
            yield return new WaitForSeconds(0.4f);
        }
        Destroy(ball);
    }

    public void DestroyBall(GameObject ball)
    {
        Destroy(ball);
        lives--;
        LivesText.text = lives.ToString();
        if(lives> 0 )
            RespawnBall();
    }

    private IEnumerator Delay(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
    
    
    
    
}