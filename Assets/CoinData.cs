using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinData
{
    public string ID;
    public bool iscollected;
    public CoinData(Coin coin)
    {
        iscollected = coin.iscollected;
        ID = coin.ID;
    }
    public CoinData()
    {
        iscollected = false;
    }
}
