using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool iscollected;
    public string ID;
    public GameObject o;
    private GameData data;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!iscollected)
            {
                data = DataHandler.LoadGameData();
                gameObject.SetActive(false);
                iscollected = true;
                Save();
                data.CoinCount += 1;
                Debug.Log("New Value " + data.CoinCount);
                DataHandler.SaveGameData(data);
                
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        iscollected = false;
        ID = gameObject.name + "-" +
            Mathf.RoundToInt(transform.position.x) +
            Mathf.RoundToInt(transform.position.y) +
            Mathf.RoundToInt(transform.position.z);
        
        LoadCoin();
        data = DataHandler.LoadGameData();
        Debug.Log("Start Value " + data.CoinCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Save()
    {
        DataHandler.SaveCoin(this, ID);
    }

    public void LoadCoin()
    {
        iscollected = DataHandler.LoadCoin(ID).iscollected;
        
        
        if(iscollected)
        {           
            var REND = gameObject.GetComponent<SpriteRenderer>();
            REND.color = new Color(REND.color.r, REND.color.g, REND.color.b, 0.5f);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
