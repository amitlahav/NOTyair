﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boundary_Behavior : MonoBehaviour {

     void OnTriggerExit2D(Collider2D Bolt)
    {
        Destroy(Bolt.gameObject);
        if (gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Prototype");
        }
    }
}
