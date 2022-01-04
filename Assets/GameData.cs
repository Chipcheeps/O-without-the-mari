using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int CoinCount;
    public GameData(int coinCount)
    {
        CoinCount = coinCount;
    }
}
