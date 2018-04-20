using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionUI : MonoBehaviour {

    public GameObject[] InfoPanel = new GameObject[Consts.QuestionsAmount];
    public GameObject[] QuestionPanel = new GameObject[Consts.QuestionsAmount];
    public GameObject PlayerUI;
    public static int CurrentQuestion = 0;
    public WeaponSwitch Weapon;

    private void Start()
    {
        CurrentQuestion = PlayerPrefs.GetInt("Question");
       
    }

    public void CorrectAnwser()
    {
        //Rewards
        UIManager.Score += 5000;
        UIManager.Potions += 3;
        Weapon.MainWeapon[Weapon.SelectedWeapon].GetComponent<WeaponsBehaviour>().Ammo += 50;
        int DropChance = Random.Range(0, 100);
        if (DropChance >= 70)
        {
            Weapon.MainWeapon[3].GetComponent<WeaponsBehaviour>().WeaponOwned = true;
        }//
        //Resuming Game
        QuestionPanel[CurrentQuestion].SetActive(false);
        PlayerUI.SetActive(true);
        if (CurrentQuestion != Consts.QuestionsAmount - 1)
        {
            PlayerPrefs.SetInt("Question", PlayerPrefs.GetInt("Question") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Question", 0);
        }
        Time.timeScale = 1f;
        //Settling Score
        UIManager.ScoreRemoved = UIManager.Score;
        UIManager.Time_From_LastLoad = UIManager.Time_FromLoad;
        UIManager.Time_FromLoad = 0;
        UIManager.Moved_Scene = true;
    }

    public void WrongAnwser()
    {
        //Penalties
        UIManager.Score -= 2000;
        int DropChance = Random.Range(0, 100);
        if (DropChance >= 70)
        {
            Weapon.MainWeapon[3].GetComponent<WeaponsBehaviour>().WeaponOwned = false;
        }//
         //Resuming Game
        QuestionPanel[CurrentQuestion].SetActive(false);
        PlayerUI.SetActive(true);
        if (CurrentQuestion != Consts.QuestionsAmount - 1)
        {
            PlayerPrefs.SetInt("Question", PlayerPrefs.GetInt("Question") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Question", 0);
        }
        Time.timeScale = 1f;
        //Settling Score
        UIManager.ScoreRemoved = UIManager.Score;
        UIManager.Time_From_LastLoad = UIManager.Time_FromLoad;
        UIManager.Time_FromLoad = 0;
        UIManager.Moved_Scene = true;
    }
    public void Continue()
    {
        InfoPanel[CurrentQuestion].SetActive(false);
        QuestionPanel[CurrentQuestion].SetActive(true);
    }
    private void Update()
    {
        if (MoveScene.QuestionTime)
        {
            Time.timeScale = 0f;
            PlayerUI.SetActive(false);
            InfoPanel[CurrentQuestion].SetActive(true);
            MoveScene.QuestionTime = false;
        }
          
    }
}
