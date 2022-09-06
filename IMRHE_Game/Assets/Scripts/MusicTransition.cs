using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicTransition : MonoBehaviour
{
    public Animator musicAnim;

    public float transitionTime = 1f;
  
    private void Update()
    {

        StartCoroutine(MusicStart());
    }

    IEnumerator MusicStart()
    {
        //musicAnim.SetTrigger("FadeOut");
        musicAnim.SetTrigger("FadeIn");

        yield return new WaitForSeconds(transitionTime);
        //SceneManager.LoadScene("Level-1");
    }


}
