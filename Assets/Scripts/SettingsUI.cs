using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsUI : MonoBehaviour
{
    public Slider Brightness;
    //public Slider Volume;
    //public Audio BgMusic;
    public GameObject Player_Panel;
    void Start()
    {
        Brightness.maxValue = 0.5f;
        Brightness.minValue = -0.5f;
        Brightness.value = PlayerPrefs.GetFloat("Brightness_Value");
    }
    void Update()
    {
        if (Brightness.value >= 0)
        {
            Player_Panel.GetComponent<Image>().color = new Color(255, 255, 255, Brightness.value);
            PlayerPrefs.SetFloat("Brightness_Value", Brightness.value);
        }
        else
        {
            Player_Panel.GetComponent<Image>().color = new Color(0, 0, 0, (Brightness.value)*-1);
            PlayerPrefs.SetFloat("Brightness_Value", (Brightness.value));
        }
    }
    public void ResetButton()
    {
        Brightness.value = 0;
    }

}
