using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitch : MonoBehaviour
{

    
   void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        
        if (other.transform.CompareTag("Player"))
        {
            Timer.timerActive = false;
            Debug.Log("Timer Off");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
             SceneManager.LoadScene("YouWinScene");
        }

    }
}
