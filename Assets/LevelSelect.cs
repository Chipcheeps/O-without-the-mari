using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Level_1()
    {
        SceneManager.LoadScene(2);
    }
    public void Level_2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level_3()
    {
        SceneManager.LoadScene(4);
    }
    public void Level_4()
    {
        SceneManager.LoadScene(5);
    }
    public void Level_5()
    {
        SceneManager.LoadScene(6);
    }
    public void Shop()
    {
        SceneManager.LoadScene(7);
    }
}
