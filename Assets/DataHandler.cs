using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public static class DataHandler
{
    public static void SaveCoin(Coin coin, string ID)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string CoinPath = Application.persistentDataPath + "/coin-" + ID + ".data";
    
        
        FileStream stream = new FileStream(CoinPath, FileMode.Create);
        CoinData coinData = new CoinData(coin);

        formatter.Serialize(stream, coinData);
        stream.Close();
    }

    public static CoinData LoadCoin(string ID)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string CoinPath = Application.persistentDataPath + "/coin-"+ID+".data";
        if (File.Exists(CoinPath))
        {
            FileStream stream = new FileStream(CoinPath, FileMode.Open);
            CoinData coinData = formatter.Deserialize(stream) as CoinData;
            stream.Close();
            return coinData;
        }
        else
        {
            CoinData coinData = new CoinData();
            coinData.iscollected = false;
            return coinData;
        }
    }
    public static GameData LoadGameData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string DataPath = Application.persistentDataPath + "/game.data";
        if (File.Exists(DataPath))
        {
            FileStream stream = new FileStream(DataPath, FileMode.Open);
            GameData gameData = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gameData;
        }
        else
        {
            GameData gameData = new GameData(0);
      
            return gameData;
        }
    }
    public static void SaveGameData(GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string DataPath = Application.persistentDataPath + "/game.data";


        FileStream stream = new FileStream(DataPath, FileMode.Create);
        

        formatter.Serialize(stream, gameData);
        stream.Close();
    }
}
