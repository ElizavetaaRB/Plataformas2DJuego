using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject initialMenu;
    private void Start()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void Play()
    {
        initialMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
