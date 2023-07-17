using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public void startButton()
    {
        SceneManager.LoadScene("PreGameScene");
    }

    public void settingsButton()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
    
    public void PreGameToLobbyButton()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    
}
