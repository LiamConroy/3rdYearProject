using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    //Variables
    public float speed;
    public float maxDistance;

    private GameObject triggeringEnemy;
    public int damage;

    private GameObject player;
    
    //Methods
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //Scene currentScene = SceneManager.GetActiveScene();  
        

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
            Destroy(this.gameObject);

    }

    public void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();  
        string sceneName = currentScene.name;

        if (other.tag == "Player")
        {
           print("Ouch!");
           SceneManager.LoadScene(sceneName);
        }
    }
}