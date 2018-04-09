using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathUI : MonoBehaviour {
    public GameObject DeathPanel;
    public GameObject Player_UI;
    public Health_System_Player Health;
    public PauseMenu Death;
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
        Player_UI.SetActive(true);
        SceneManager.LoadScene(Consts.Current_Scene);
    }
}
