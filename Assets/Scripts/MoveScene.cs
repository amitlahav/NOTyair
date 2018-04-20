using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveScene : MonoBehaviour {
    // summ later

    bool load = false;
    public Vector2 SpawnPoint; 
    public static bool QuestionTime = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!load)
        {
            if (other.gameObject.tag == "Player" /*&& GameObject.FindGameObjectWithTag("Enemy") == null*/)
            {
                load = true;
                other.gameObject.transform.position = SpawnPoint;
                StartCoroutine(ChangeScene(other.gameObject, Consts.Current_Scene+1));
                Consts.Current_Scene++;
                QuestionTime = true;
            }
        }
    }
   public IEnumerator ChangeScene(GameObject Player,int nextSceneIndex)
    {
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);
        Scene NextScene = SceneManager.GetSceneAt(1);
        SceneManager.MoveGameObjectToScene(Player, NextScene);
        yield return null;
        SceneManager.UnloadSceneAsync(nextSceneIndex-1);
    }
}
