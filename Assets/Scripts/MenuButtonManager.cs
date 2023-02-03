using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{

    [SerializeField] private GameObject option;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void Resume()
    {
        option.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
