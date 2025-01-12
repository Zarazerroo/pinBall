using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    [SerializeField]
    private float scaleAmount = 0.01f*100f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increase Scale 
        if (Input.GetKey("a"))
            transform.ScaleXLeftEdge(scaleAmount);
        
        if (Input.GetKey("d"))
            transform.ScaleXRightEdge(scaleAmount);
        
        if (Input.GetKey("s"))
            transform.ScaleYBottomEdge(scaleAmount);
        
        if (Input.GetKey("w"))
            transform.ScaleYUpperEdge(scaleAmount);
        
        //Reduce Scale  
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.ScaleXLeftEdge(-scaleAmount);
        
        if (Input.GetKey(KeyCode.RightArrow))
            transform.ScaleXRightEdge(-scaleAmount);
        
        if (Input.GetKey(KeyCode.DownArrow))
            transform.ScaleYBottomEdge(-scaleAmount);
        
        if (Input.GetKey(KeyCode.UpArrow))
            transform.ScaleYUpperEdge(-scaleAmount);
    }
}
