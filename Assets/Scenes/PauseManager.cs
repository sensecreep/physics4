using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public TMP_Text buttonText; // Ссылка на текст кнопки

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        // Меняем текст кнопки
        if (buttonText != null)
        {
            buttonText.text = isPaused ? "Play" : "Pause";
        }
    }
}