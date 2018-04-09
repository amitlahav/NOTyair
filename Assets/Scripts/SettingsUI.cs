using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsUI : MonoBehaviour {
    public Slider Brightness;
    public Slider Volume;
    public Audio BgMusic;
    public Image Alpha;
    public Image SettingsAlpha;
    Color Settings;
    void Start()
    {
        Brightness.maxValue = 255;
        Volume.maxValue = 100;
        Settings = SettingsAlpha.color;
        
    }
    void Update()
    {
        Time.timeScale = 0f;
        Color color = Alpha.color;
        color.a = Brightness.value;
        Settings.a = color.a;
    }
}
