﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPauseMenu : MonoBehaviour, IPointerClickHandler
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;



    public void OnPointerClick(PointerEventData eventData)
    {

        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("StartPage");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
