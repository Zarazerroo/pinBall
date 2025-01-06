// Copyright Abdulaziz Alonizi 2025

using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private Text time;
    private float counter = 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //time.text = counter.ToString(); 
        if(Input.GetKey("s")){
            counter += Time.deltaTime;
        }
        
        if (Input.GetKeyUp("s"))
        {
            KickBall();
            counter = 0;
        }
    }

    private void KickBall()
    {
        
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,3*counter*100f));
    }
}
