using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 

public class startgame : MonoBehaviour
{
    public Animator Transition;
    public float TransitionTime;
    public void StartTheGame() 
    { 
        LoadNextScene();               
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(1));
        //SceneManager.LoadScene(1);
    }

    IEnumerator LoadLevel (int LevelIndex)
    {
        //play animation
        Transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(TransitionTime);
        //load scene
        SceneManager.LoadScene(LevelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
