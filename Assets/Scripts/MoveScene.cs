using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveScene : MonoBehaviour {
    bool load = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!load)
        {
            load = true;
            if (other.gameObject.tag == "Player")
            {
                StartCoroutine(ChangeScene(other.gameObject, Consts.Current_Scene+1));
                Consts.Current_Scene++;
                Debug.Log(Consts.Current_Scene);
            }
        }
    }
    IEnumerator ChangeScene(GameObject Player,int nextSceneIndex)
    {
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);
        Scene NextScene = SceneManager.GetSceneAt(1);
        SceneManager.MoveGameObjectToScene(Player, NextScene);
        yield return null;
        SceneManager.UnloadSceneAsync(nextSceneIndex-1);
    }

}
