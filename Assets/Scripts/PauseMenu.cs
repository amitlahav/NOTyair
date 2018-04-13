using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    /*/<Summary>
     * Pause menu - Comes up when Escape key is pressed
     * pausing the game 
     * open options to Quit game
     * Resume game
     * open the settings menu
     * quit to main menu
     * </Summary>
     * <Logic>
     * Only openable when alive
     * pressing escape pausing and resuming the game based on a boolean
     * resuming game - setting the boolean false - activating the player UI - setting another UI as false - return the time scale to normal
     * Pause game - setting the boolean true - deactivating the player UI - activating the Pause panel - stopping time
     * Game Menu - resuming time for a frame - in that frame activating the setting UI and the Player UI
     * Quit to Main Menu - resuming time and opening the main menu Scene
     * </Logic>/*/

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
