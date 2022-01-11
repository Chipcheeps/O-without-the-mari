using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    public static bool ispaused = false;
    public GameObject[] coins;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }
    public void resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }
    public void pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void Quit()
    {
        SceneManager.LoadScene(1);
    }

    public void Resetcoins()
    {
        foreach (GameObject c in coins)
        {
            c.GetComponent<Coin>().iscollected = false;
            c.GetComponent<Coin>().Save();
            c.GetComponent<Coin>().LoadCoin();
        }
    }
}
