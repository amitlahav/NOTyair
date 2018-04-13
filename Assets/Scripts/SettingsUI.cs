using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsUI : MonoBehaviour
{
    /*<Summary>
     * #This is the Settings UI, His panel works all the time
     * #this UI works when the player presses the menu button after pause
     * #In this UI the player can set the Brightness of the game
     * and the Volume of the Audio
     * </Summary>
     * <Logic>
     * #There are 2 Sliders - 1 for the changing of the Volume
     * and one for the changing of the Brightness
     * if the Brightness Slider is Above the half the panel of the UI turns White
     * and Decreasing the Alpha-Opaque-
     * #if the Brightness Slider is Below the half the panel turns black
     * and Deacrasing the Alpha-Opaque-
     * #The Slider's Value is saved on "PlayerPrefs".
     * </Logic>*/
    public Slider Brightness;
    public Slider Volume;
    public AudioSource BgMusic;
    public GameObject Player_Panel;
    void Start()
    {
        Volume.maxValue = 1f;
        Volume.minValue = 0f;
        Volume.value = 0.05f;
        Brightness.maxValue = 0.5f;
        Brightness.minValue = -0.5f;
        Brightness.value = PlayerPrefs.GetFloat("Brightness_Value");
        Volume.value = PlayerPrefs.GetFloat("Volume_Value");
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
        BgMusic.GetComponent<AudioSource>().volume = Volume.value;
        PlayerPrefs.SetFloat("Volume_Value", Volume.value);
    }
    public void ResetButton()
    {
        Brightness.value = 0;
    }

}
