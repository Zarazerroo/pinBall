using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartButton : MonoBehaviour
{
    public void StartTheGame() 
    { 
        SceneManager.LoadScene("Submit Plz"); 
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
