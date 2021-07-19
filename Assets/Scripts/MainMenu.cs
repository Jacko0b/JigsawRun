using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class MainMenu : MonoBehaviour
{
    public void Play(bool tutorial)
    {
        Time.timeScale = 1;
        if(tutorial)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Daria()
    {
        SceneManager.LoadScene(5);
    }

}
