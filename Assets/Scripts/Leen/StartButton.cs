using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartButton : MonoBehaviour
{
    public void StartTheGame() 
    { 
        SceneManager.LoadScene("Full game M"); 
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
