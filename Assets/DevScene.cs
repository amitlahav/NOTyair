using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DevScene : MonoBehaviour {
    
	public void Game1()
    {
        SceneManager.LoadScene(2);
    }
    public void Game2()
    {
        SceneManager.LoadScene(3);
    }
    public void Game3()
    {
        SceneManager.LoadScene(4);
    }
    public void Bonus()
    {
        SceneManager.LoadScene(6);
    }
}
