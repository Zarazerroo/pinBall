using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public float TransitionTime;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
               
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
}
