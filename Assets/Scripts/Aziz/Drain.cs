using System;
using Unity.VisualScripting;
using UnityEngine;

public class Drain : MonoBehaviour
{
    private LevelController lvlController; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lvlController = FindAnyObjectByType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        lvlController.DestroyBall(other.gameObject);
    }
}
