using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu : MonoBehaviour {
    /*/<Summary>
     * Main Menu Scene - Play or Quit
     * </Summary>
     * <Logic>
     * Clicking Playgame starts the first scene
     * Click Quit Game - Closing the Application
     * </Logic>/*/
    public void Start()
    {
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(Consts.Game1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }

}
