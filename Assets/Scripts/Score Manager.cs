using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int Health;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        Health = 3;
    }
    void Update()
    {
        if (Health<0)
        {
            Health = 0;
        }
        text.text = "" + Health;
    }
    public static void AddHealth(int HealthToAdd)
    {
        Health += HealthToAdd;
    }
    public static void Reset()
    {
        Health = 3;
    }
}
