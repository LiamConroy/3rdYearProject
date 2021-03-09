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
            SceneManager.LoadScene("YouWinScene");
            Timer.timerActive = false;
            Debug.Log("Timer Off");
        }

    }
}
