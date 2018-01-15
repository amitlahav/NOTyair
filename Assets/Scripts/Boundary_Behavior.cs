using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_Behavior : MonoBehaviour {

     void OnTriggerExit2D(Collider2D Bolt)
    {
        Destroy(Bolt.gameObject);
        if (gameObject.tag == "Player")
        {
            Application.LoadLevel("Prototype");
        }
    }
}
