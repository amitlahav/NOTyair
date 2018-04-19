using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Extermination : MonoBehaviour {

    public Button Anwser;
    public WeaponSwitch Weapon;
    public GameObject PlayerUI;
    public List<GameObject> Questions = new List<GameObject>();
    public void WrongAnwser()
    {
        UIManager.Score -= 1400;
        Weapon.MainWeapon[4].GetComponent<WeaponsBehaviour>().WeaponOwned = false;
        PlayerUI.SetActive(true);
        PauseMenu.IsPaused = false;
        Time.timeScale = 1f;
    }
    public void CorrectAnwser()
    {
        UIManager.Score += 5000;
        Weapon.MainWeapon[Weapon.SelectedWeapon].GetComponent<WeaponsBehaviour>().Ammo += 50;
        UIManager.Potions += 3;
        int DropChance = Random.Range(0, 100);
        if (DropChance >=60)
        {
            Weapon.MainWeapon[4].GetComponent<WeaponsBehaviour>().WeaponOwned = true;
        }
        PlayerUI.SetActive(true);
        Questions[MoveScene.QuestionCounter].SetActive(false);
        PauseMenu.IsPaused = false;
        Time.timeScale = 1f;
    }
}
