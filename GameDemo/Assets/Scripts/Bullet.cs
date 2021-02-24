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
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
            Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           print("Ouch!");
           SceneManager.LoadScene("LevelOne");
        }
    }
}