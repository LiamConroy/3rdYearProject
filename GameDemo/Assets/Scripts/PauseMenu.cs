using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   // public GameObject Player;
    public static bool GameIsPaused = false;
    public GameObject PauseMenuOverlay;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            
            if (GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }

        }
    }

    void Resume(){
        Debug.Log("Running");
        PauseMenuOverlay.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Pause(){
        Debug.Log("Paused");
        PauseMenuOverlay.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

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
        Debug.Log("Switched ControlsScene");
    }
}
