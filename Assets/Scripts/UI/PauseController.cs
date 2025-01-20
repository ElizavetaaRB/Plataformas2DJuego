using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }  
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
