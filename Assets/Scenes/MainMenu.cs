using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartTask1()
    {
        SceneManager.LoadScene("Task1");
    }
    public void StartTask2()
    {
        SceneManager.LoadScene("Task2");
    }
    public void StartTask3()
    {
        SceneManager.LoadScene("Task3");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
