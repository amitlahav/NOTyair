using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bonus_Scene : MonoBehaviour {
    /*/<Summary>
     * Sending the Player to a bonus level Scene
     * when going thorugh a door
     * Script works for 3 occasuions:
     * #Enter to the bonus level from the main levels
     * #Exit the bonus level to the main levels through door
     * #Exit the bonus level when failing to complete succesfully
     * </Summary>
     * <Logic>
     * On collision with the door or game boundry starting the
     * Courtine from MoveScene.cs 
     * </Logic>/*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(Consts.Game2))
        {
            UIManager.Bonus_Score = UIManager.Score;
            collision.gameObject.transform.position = new Vector2(-180.3675f, 217.6451f);
            ChangeToBonusCamera(collision.gameObject);
            Destroy(transform.gameObject);
            StartCoroutine(ChangeToBonusScene(collision.gameObject, Consts.Bonus_Scene));
        }
        else if (collision.gameObject.tag == "Player" && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(Consts.Bonus_Scene))
        {
            collision.gameObject.transform.position = new Vector2(-130.3026f, 23.9669f);
            ChangeToMainCamera(collision.gameObject);
            StartCoroutine(LeaveBonusScene(Consts.Bonus_Scene));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.Score = UIManager.Bonus_Score;
            collision.gameObject.transform.position = new Vector2(-130.3026f, 23.9669f);
            ChangeToMainCamera(collision.gameObject);
            StartCoroutine(LeaveBonusScene(Consts.Bonus_Scene));
        }
    }

    public IEnumerator ChangeToBonusScene(GameObject Player, int BonusScene)
    {
        SceneManager.LoadScene(BonusScene, LoadSceneMode.Additive);
        yield return null;
    }
    public IEnumerator LeaveBonusScene(int BonusScene)
    {
        SceneManager.UnloadSceneAsync(BonusScene);
        yield return null;
    }
    public void ChangeToBonusCamera(GameObject Player)
    {
        foreach (Transform Children in Player.transform)
        {
            if (Children.name == "Bonus_Camera")
            {
                Children.gameObject.SetActive(true);
            }
            if (Children.name == "Main Camera")
            {
                Children.gameObject.SetActive(false);
            }
        }
    }
    public void ChangeToMainCamera(GameObject Player)
    {
        foreach (Transform Children in Player.transform)
        {
            if (Children.name == "Bonus_Camera")
            {
                Children.gameObject.SetActive(false);
            }
            if (Children.name == "Main Camera")
            {
                Children.gameObject.SetActive(true);
            }
        }
    }
}
