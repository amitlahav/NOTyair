using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boundary_Behavior : MonoBehaviour {
    /*/<Summary>
     * Controlling game boundry
     * </Summary>
     * <Logic>
     * upon exiting the OnTrigger BoxCollider2D
     * Destroy GameObject
     * Unless gameobject is @Player
     * # Sending to Game1
     * </Logic>/*/
     void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
        Destroy(collision.gameObject);
    }
}
