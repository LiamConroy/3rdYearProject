using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private GameObject triggeringEnemy;
    public float speed = 8f;
    public float damage = 100f;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
            print("Got em!");
        }
    }
}
