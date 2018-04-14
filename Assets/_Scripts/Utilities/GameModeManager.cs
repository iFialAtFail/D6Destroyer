using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameModeManager : ScriptableObject
{

    public int Difficulty { get; set; }

    public void StartGame()
    {
        SceneManager.LoadScene("survival", LoadSceneMode.Single);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

    public void GotoZenMode(){
        SceneManager.LoadScene("ZenMode", LoadSceneMode.Single);
    }

    public void GotoStoryMode(){
        
    }
}
