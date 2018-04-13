using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator : MonoBehaviour {

    public GameObject Platform;
    public Transform GenerationPoint_1;
    public Transform GenerationPoint_2;
    public Transform GenerationPoint_3;
    public Camera Main_Camera;
    public Camera Bonus_Camera;
    private float Time_Between;
    private int Random_Point;
    private int Previous_Point;

    void Start()
    {
        Time_Between = 1f;
        Main_Camera.gameObject.SetActive(false);
        Bonus_Camera.gameObject.SetActive(true);
    }

    public void Update()
    {
        if (Time.time > Time_Between)
        {
            Time_Between = Time.time + 2f;
            Random_Point = Random.Range(1, 4);
            if (Random_Point == 1)
            {
                Instantiate(original: Platform, position: GenerationPoint_1.position, rotation: GenerationPoint_1.rotation);
            }
            else if (Random_Point == 2)
            {
                Instantiate(original: Platform, position: GenerationPoint_2.position, rotation: GenerationPoint_2.rotation);
            }
            else if (Random_Point == 3)
            {
                if (Previous_Point == 1)
                {
                    Instantiate(original: Platform, position: GenerationPoint_2.position, rotation: GenerationPoint_2.rotation);
                }
                else
                {
                    Instantiate(original: Platform, position: GenerationPoint_3.position, rotation: GenerationPoint_3.rotation);
                }
            }
            Previous_Point = Random_Point;
        }
    }
}
