using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    private float gameOverTime = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<GameManager>().alive)
        {
            if (!GameIsPaused) Pause();
            else Resume();
        }

        if(!FindObjectOfType<GameManager>().alive)
        {
            if(gameOverTime > 0)
            {
                gameOverTime -= Time.deltaTime;
            }
            else
            {
                gameOverMenuUI.SetActive(true);
            }            
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
