using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveSelect : MonoBehaviour
{
     public void LevelOne () {
          SceneManager.LoadScene("LevelOne");
     }

     public void LevelTest () {
          SceneManager.LoadScene("LevelTest");
     }

     public void Back(){
         SceneManager.LoadScene("MainMenu");
     }
}
