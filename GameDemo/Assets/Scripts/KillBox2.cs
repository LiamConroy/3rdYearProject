using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox2 : MonoBehaviour
{



void Update(){
        //Restart 
     
     
 }

  void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        Scene currentScene = SceneManager.GetActiveScene();  
        string sceneName = currentScene.name;
        
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("game restart");
            SceneManager.LoadScene(sceneName);
        }
    }
}
