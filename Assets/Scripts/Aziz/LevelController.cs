using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Text LivesText;
    [SerializeField] private GameObject ballPrefab;

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
        
        Instantiate(ballPrefab, new Vector3(-5.595f, 4.191f, 0f), quaternion.identity);
        
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