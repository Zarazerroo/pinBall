using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{   
    Text scoreText;
    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Text component that is attached to this object, which will display the score
        scoreText = GetComponent<Text>(); 
        // score 0 - int -> string
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int points) 
    { 
        // add 1 to the score
        score = score + points; 
        // update the score , int -> string
        scoreText.text = score.ToString(); 
    } 

}
