using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartButton : MonoBehaviour
{
    public void StartTheGame() 
    { 
        SceneManager.LoadScene("Leen"); 
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
