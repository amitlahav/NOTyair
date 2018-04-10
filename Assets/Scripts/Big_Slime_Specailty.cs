using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Slime_Specailty : MonoBehaviour {

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
            
            Debug.Log("x");
            Instantiate(original: Small_Slime, position:new Vector3(transform.position.x+2,transform.position.y,transform.position.z), rotation: transform.rotation);
            Instantiate(original: Small_Slime, position: new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), rotation: transform.rotation);
            EnemyMade = true;
            yield return null;
        }
    }
}
