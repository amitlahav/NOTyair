using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator : MonoBehaviour {

    /*/<Summary>
     * Generating platforms for the bonus level
     * each platform is generated at a different random position after a specific time
     * </Summary>
     * <Logic>
     * Spawning a prefab moving object every few seconds 
     * at a different position determined by a random variable after a timer ends
     * saving position to not create an impossible jump
     * switching to a different camera - better for the bonus mode
     * </Logic>/*/

    public GameObject Platform;
    public Transform GenerationPoint_1;
    public Transform GenerationPoint_2;
    public Transform GenerationPoint_3;
    private float Time_Between;
    private int Random_Point;
    private int Previous_Point;

    void Start()
    {
        Time_Between = 1f;
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
