﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject PauseMenuPanel;
    public GameObject PlayerUI;
    public GameObject SettingsUI;
    public bool IsDead = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!IsDead)
        {
            Debug.Log("pause");
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
          
    }

    public void ResumeGame()
    {
        IsPaused = false;
        PlayerUI.SetActive(true);
        PauseMenuPanel.SetActive(false);
        SettingsUI.SetActive(false);
        Time.timeScale = 1f;
    }
    void PauseGame()
    {
        IsPaused = true;
        PlayerUI.SetActive(false);
        PauseMenuPanel.SetActive(true);
        
        Time.timeScale = 0f;
    }
    public void GameMenu()
    {
        Time.timeScale = 1f;
        PauseMenuPanel.SetActive(false);
        PlayerUI.SetActive(true);
        SettingsUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Consts.MAIN_MENU);
    }
}
