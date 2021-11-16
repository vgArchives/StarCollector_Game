using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(PlayGameHelper());
    }

    IEnumerator PlayGameHelper()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
