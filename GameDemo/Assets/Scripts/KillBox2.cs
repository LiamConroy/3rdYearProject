using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox2 : MonoBehaviour
{
  void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        
        if (other.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene("LevelOne");
        }
    }
}
