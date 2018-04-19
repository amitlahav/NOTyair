using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Slime_Specailty : MonoBehaviour {
    /*/<Summary>
     * Feature the Big Slimes have
     * Upon death spliting into 2
     * </Summary>
     * <Logic>
     * When the Slime dies, spawn 2 smaller slimes in a 
     * predetermined positions that based upon his
     * </Logic>/*/

    public Health_System_Enemies Big_Slime;
    public GameObject Small_Slime;
    bool EnemyMade = false;
    private void Update()
    {
        StartCoroutine("Spawnlings");
    }
    IEnumerator Spawnlings()
    {
        if (Big_Slime.Health <= 0&&EnemyMade == false)
        {
            
            Instantiate(original: Small_Slime, position:new Vector3(transform.position.x+2,transform.position.y,transform.position.z), rotation: transform.rotation);
            Instantiate(original: Small_Slime, position: new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), rotation: transform.rotation);
            EnemyMade = true;
            yield return null;
        }
    }
}
