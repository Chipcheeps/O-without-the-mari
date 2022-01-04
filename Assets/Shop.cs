using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private GameData gameData;
    public TextMeshProUGUI CoinText;
    // Start is called before the first frame update
    void Start()
    {
        gameData = DataHandler.LoadGameData();
        CoinText.text = gameData.CoinCount.ToString() + "/" + (100).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
