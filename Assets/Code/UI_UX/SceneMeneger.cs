using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMeneger : MonoBehaviour
{
    public void LoadScene(string newScene){
        SceneManager.LoadScene(newScene);

    }

    public void QuitTheGame(){
        Application.Quit();
    }
    
}
