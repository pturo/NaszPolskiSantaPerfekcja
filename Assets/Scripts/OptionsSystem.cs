using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsSystem : MonoBehaviour
{
    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
