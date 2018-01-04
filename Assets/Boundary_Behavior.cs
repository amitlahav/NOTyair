using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_Behavior : MonoBehaviour {

     void OnTriggerExit(Collider Bolt)
    {
        Destroy(Bolt.gameObject);
    }
}
