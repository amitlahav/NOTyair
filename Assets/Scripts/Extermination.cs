using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Extermination : MonoBehaviour {

    public WeaponSwitch Weapon;
    public GameObject PlayerUI;
    public static bool Pop_Question = false;
    public GameObject[] Info_Panel = new GameObject[Consts.QuestionsAmount];
    public GameObject[] Question_Panel = new GameObject[Consts.QuestionsAmount];
    public int QuestionCounter = 0;
    private void Update()
    {
        if (Pop_Question)
        {
            PlayerUI.SetActive(false);
            Info_Panel[QuestionCounter].SetActive(true);  
            PauseMenu.IsPaused = true;
            Pop_Question = false;
            Time.timeScale = 0f;
        }
    }
    public void WrongAnwser()
    {
        Time.timeScale = 1f;
        UIManager.Score -= 1400;
        Weapon.MainWeapon[4].GetComponent<WeaponsBehaviour>().WeaponOwned = false;
        Question_Panel[QuestionCounter].SetActive(false);
        PlayerUI.SetActive(true);
        PauseMenu.IsPaused = false;
        QuestionCounter++;
    }
    public void CorrectAnwser()
    {
        Time.timeScale = 1f;
        UIManager.Score += 5000;
        Weapon.MainWeapon[Weapon.SelectedWeapon].GetComponent<WeaponsBehaviour>().Ammo += 50;
        UIManager.Potions += 3;
        int DropChance = Random.Range(0, 100);
        if (DropChance >=60)
        {
            Weapon.MainWeapon[4].GetComponent<WeaponsBehaviour>().WeaponOwned = true;
        }
        PlayerUI.SetActive(true);
        Question_Panel[QuestionCounter].SetActive(false);
        PauseMenu.IsPaused = false;
        QuestionCounter++;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        Question_Panel[QuestionCounter].SetActive(true);
        Info_Panel[QuestionCounter].SetActive(false);
        Time.timeScale = 0f;
    }
}
