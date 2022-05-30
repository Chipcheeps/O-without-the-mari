using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject o;
    public GameObject GameOver;
    public GameObject DroneGenerator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (o.GetComponent<o>().Health <= 0)
        {
            GameOver.SetActive(true);
            o.GetComponent<o>().GameOver = true;
            Color oldcolor = o.GetComponent<SpriteRenderer>().color;
            Color newcolor = new Color(oldcolor.r, oldcolor.g, oldcolor.b, 0f);
            o.GetComponent<SpriteRenderer>().color = newcolor;
            if (Input.anyKey)
            {
                o.GetComponent<o>().Respawn();
                GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
                Debug.Log(Enemies.Length);
                foreach (GameObject enemy in Enemies)
                {
                    try
                    {
                        Debug.Log(enemy.name + " good");
                        if (enemy.name.Equals("Drone(Clone)"))
                        {
                            Destroy(enemy);
                            DroneGenerator.GetComponent<Drone_Generator>().DroneCount--;
                        }
                        else
                        {
                            enemy.GetComponent<RespawnScript>().Return();
                        }
                        
                    }
                    catch (NullReferenceException e) 
                    { 
                     Debug.Log(enemy.name + " null");
                    }

                }
            }

        }
        else
        {
            GameOver.SetActive(false);
            o.GetComponent<o>().GameOver = false;
        }
            
    }
}
