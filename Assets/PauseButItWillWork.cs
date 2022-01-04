using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseButItWillWork: MonoBehaviour
{
    public GameObject Menu;
    public bool ispaused;
    public bool issettings;
    public GameObject SettingsPanel;
    public TMP_Dropdown ResDrop;
    Resolution[] resolutions;
    public GameObject o;
    // Start is called before the first frame update
    void Start()
    {
        ispaused = false;
        Menu.SetActive(false);
        SettingsPanel.SetActive(false);
        resolutions = Screen.resolutions;
        ResDrop.ClearOptions();
        List<string> options = new List<string>();
        int CurrentRes = 0;
        for(int x = 0; x < resolutions.Length; x++)
        {
            string option = resolutions[x].width + " x " + resolutions[x].height;
            options.Add(option);
            if(resolutions[x].width == Screen.currentResolution.width && resolutions[x].height == Screen.currentResolution.height)
            {
                CurrentRes = x;
            }
        }
        ResDrop.AddOptions(options);
        ResDrop.value = CurrentRes;
        ResDrop.RefreshShownValue();
        Resume();
    }
    public void Resume()
    {
        Menu.SetActive(false);
        SettingsPanel.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
        issettings = false;
    }
    public void Pause()
    {
        Menu.SetActive(true);
        SettingsPanel.SetActive(false);
        Time.timeScale = 0f;
        ispaused = true;
        issettings = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused && !issettings)
            {
                Resume();
            }
            else
            {
                Pause();
            }
           

        }
    }
    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowSettings()
    {
        SettingsPanel.SetActive(true);
        Menu.SetActive(false);
        issettings = true;
    }
    public void HideSettings()
    {
        SettingsPanel.SetActive(false);
        Menu.SetActive(true);
        issettings = false;
    }
    public void SetQuality(int Index)
    {
        QualitySettings.SetQualityLevel(Index);
    }
    public void SetFullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }
    public void SetResolution(int Resindex)
    {
        Resolution resolution = resolutions[Resindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    //public void Resetcoins()
    //{
    //    foreach (GameObject c in coins)
    //    {
    //        if(c.GetComponent<Coin>().iscollected)
    //        {
    //            c.GetComponent<Coin>().iscollected = false;
    //            c.GetComponent<Coin>().Save();
    //            c.GetComponent<Coin>().LoadCoin();
    //            c.GetComponent<SpriteRenderer>().color = new Color(c.GetComponent<SpriteRenderer>().color.r, c.GetComponent<SpriteRenderer>().color.g, c.GetComponent<SpriteRenderer>().color.b, 1f);

    //        }
    //    }
    //    o.GetComponent<o>().NumOfCoins = 0;
    //    GameData gameData = new GameData(0);
    //    DataHandler.SaveGameData(gameData);
    //}
}
