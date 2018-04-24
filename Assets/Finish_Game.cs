using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Finish_Game : MonoBehaviour {
    public Text YourScore;
    public Button Quit;
	// Update is called once per frame
	void Update () {
        YourScore.text = "Your Score: " + UIManager.Score;
	}
    public void QuitMainMenu()
    {
        SceneManager.LoadScene(Consts.MAIN_MENU);
        Consts.Current_Scene = Consts.Game1;
    }
}
