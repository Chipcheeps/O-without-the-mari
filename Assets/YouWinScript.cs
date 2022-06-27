using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWinScript : MonoBehaviour
{
    public bool win;
    public GameObject YouWin;
    // Start is called before the first frame update
    void Start()
    {
        win = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(Enemies.Length);
        foreach(GameObject enemy in Enemies)
        {
            if (enemy.activeSelf)
            {
                win = false;
            } 
        }
        if (Enemies.Length == 0)
        {
            win = true;
        }
        if (win)
        {
            YouWin.SetActive(true);
        }
    }
}
