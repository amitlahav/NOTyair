using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathUI : MonoBehaviour {
    /*/<Summary>
 * This is the UI the comes up after the players Death
 * Has a Quit Game option, and a Respawn Option
 * </Summary>
 * <Logic>
 * When Player Dies, Activating The death panel
 * Disabling the Player UI
 * #Respawning - reseting the score,reseting Current scene
 * starting off first scene
 * </Logic>*/

    public GameObject DeathPanel;
    public GameObject Player_UI;
    public Health_System_Player Health;
    public PauseMenu Death;
    public GameObject Player;

    private void Start()
    {
        DeathPanel.SetActive(false);
    }
    void Update()
    {

        if (Health.CurrentHealth <= 0)
        {
            DeathPanel.SetActive(true);
            Player_UI.SetActive(false);
            Death.IsDead = true;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Respawn()
    {
        Consts.Current_Scene = 1;
        UIManager.Score = 0;
        UIManager.Time_FromLoad = 0;
        if (PlayerPrefs.GetInt("Question") == Consts.QuestionsAmount - 1)
        {
            PlayerPrefs.SetInt("Question", 0);
        }
        SceneManager.LoadScene(1);  
    }
}
