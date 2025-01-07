using UnityEngine;

public class Points : MonoBehaviour
{
    ScoreKeeper theScoreKeeper; 
    [SerializeField] int points = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        theScoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    { 
        theScoreKeeper.IncreaseScore(points);         
    }
}
