using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private LevelController lvlController;
    private bool shredder = false ;
    private Vector3 shredderPosition;
    private GameObject ball; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shredderPosition = transform.position;
        lvlController = FindAnyObjectByType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (shredder )
        {
            ball.transform.localScale -= new Vector3(0.0025f,0.0025f);
            float random1 = Random.Range(-.1f, .1f);
            float random2 = Random.Range(-.1f, .1f);
            ball.transform.position = shredderPosition + new Vector3(random1, random2,0f);
            //ball.transform.position = ballInitialPosition;
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ball = other.gameObject;
        ball.GetComponent<Rigidbody2D>().gravityScale = 0;
        //StartCoroutine(Delay(0.25f));
        //shakeBall(other.gameObject);
        shredder = true; 
        StartCoroutine(lvlController.spawnSmallerBalls(transform.position, 5, other.gameObject));
        //StartCoroutine(Delay(2f));
        //shredder = false;
    }

    // private void shakeBall(GameObject ball)
    // {
    //     
    //     //ball.GetComponent<Rigidbody2D>().gravityScale = 0;
    //     for (int i = 0; i < 10; i++)
    //     {
    //         float random1 = Random.Range(-.1f, .1f);
    //         float random2 = Random.Range(-.1f, .1f);
    //         ball.transform.Translate(new Vector2(random1, random2));
    //     }
    // }

    private IEnumerator Delay(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}