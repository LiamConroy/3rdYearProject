using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killBox : MonoBehaviour
{
    //string sceneName = currentScene.name;

    void Update(){
        //Restart 
     //Scene currentScene = SceneManager.GetActiveScene();  
     
 }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Scene currentScene = SceneManager.GetActiveScene();  
            string sceneName = currentScene.name;

            SceneManager.LoadScene(sceneName);
        }
    }
}
