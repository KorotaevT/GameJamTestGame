using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public void startButton()
    {
        SceneManager.LoadScene("SecondScene");
    }

    public void settingsButton()
    {
        
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
    
}
