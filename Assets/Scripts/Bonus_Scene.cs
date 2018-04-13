using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bonus_Scene : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            StartCoroutine(ChangeScene(collision.gameObject, Consts.Bonus_Scene));
        }
        else if (collision.gameObject.tag == "Player" && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(7))
        {
            StartCoroutine(ChangeScene(collision.gameObject, Consts.Current_Scene));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ChangeScene(collision.gameObject, Consts.Current_Scene));
        }
    }

    public IEnumerator ChangeScene(GameObject Player, int nextSceneIndex) // copied from the MoveScene Script
    {
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);
        Scene NextScene = SceneManager.GetSceneAt(1);
        SceneManager.MoveGameObjectToScene(Player, NextScene);
        yield return null;
        SceneManager.UnloadSceneAsync(nextSceneIndex - 1);
    }
}
