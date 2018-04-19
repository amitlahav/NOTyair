using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveScene : MonoBehaviour {
    // summ later

    bool load = false;
    public Vector2 SpawnPoint;
    public GameObject PlayerUI;
    public GameObject[] Questions = new GameObject[Consts.QuestionsAmount];
    public static int QuestionCounter = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!load)
        {
            if (other.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                load = true;
                SpawnPoint = new Vector2(other.transform.position.x,other.transform.position.y);
                StartCoroutine(ChangeScene(other.gameObject, Consts.Current_Scene+1));
                UIManager.ScoreRemoved = UIManager.Score;
                UIManager.Time_From_LastLoad = UIManager.Time_FromLoad;
                UIManager.Moved_Scene = true;
                UIManager.Time_FromLoad = 0;
                Consts.Current_Scene++;
                Debug.Log(Consts.Current_Scene);
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
    public void Question(Collider2D other)
    {
        PlayerUI.SetActive(false);
        Questions[QuestionCounter].SetActive(true);
        QuestionCounter++;
        PauseMenu.IsPaused = true;
        Time.timeScale = 0f;
    }

}
