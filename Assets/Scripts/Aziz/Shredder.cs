using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab; 
    private bool shredder = false ;
    private Vector3 shredderPosition;
    private GameObject ball;
    private LevelController lvlController;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shredderPosition = transform.position;
        lvlController = FindAnyObjectByType<LevelController>();
    }

    void FixedUpdate()
    {
        if (shredder )
        {
            ball.transform.localScale -= new Vector3(0.0025f,0.0025f);
            float random1 = Random.Range(-.1f, .1f);
            float random2 = Random.Range(-.1f, .1f);
            ball.transform.position = (shredderPosition + new Vector3(random1, random2,0f));
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ball = other.gameObject;
        ball.GetComponent<Rigidbody2D>().gravityScale = 0;
        shredder = true;
        StartCoroutine(SpawnSmallerBalls(transform.position, 5, other.gameObject));
    }
    
    private IEnumerator SpawnSmallerBalls(Vector3 spawnLocation ,int ballsCount ,GameObject ball)
    {
        lvlController.ballsCount = ballsCount;
        for (int i = 0; i <= ballsCount; i++)
        { 
            var smallBall = Instantiate(ballPrefab, spawnLocation, Quaternion.identity);
            smallBall.layer = 4;
            smallBall.transform.localScale *= .4f;
            float random1 = Random.Range(-50f,50f);
            float random2 = Random.Range(-50f,50f);
            smallBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(random1*5f,random2*5f));
            yield return new WaitForSeconds(0.4f);
        }
        Destroy(ball);
        
    }
}