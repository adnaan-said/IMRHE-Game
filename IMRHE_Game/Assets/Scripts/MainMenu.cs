using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator transition;

    public Animator musicAnim;
    
    public float transitionTime = 1f;

    public void PlayGame()
    {
        LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play anim
        transition.SetTrigger("Start");
        musicAnim.SetTrigger("FadeOut");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //LoadScence
        SceneManager.LoadScene(levelIndex);
    }

   
}
