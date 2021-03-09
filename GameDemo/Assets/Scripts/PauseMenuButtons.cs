using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuButtons : MonoBehaviour
{
public void MainMenu() {
      SceneManager.LoadScene("MainMenu");  
      Debug.Log("Switched MainMenu");
}

    public void QuitGame (){
        Debug.Log("GameQuit");
        Application.Quit();
    }

    public void Controls(){
        SceneManager.LoadScene("Controls");
        Debug.Log("Switched Controls");
    }
}
