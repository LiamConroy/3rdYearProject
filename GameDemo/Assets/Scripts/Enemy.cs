
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
//using UnityEngine.Collection;
//using UnityEngine.Collection.Generic;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;
    public float lookRadius = 10f; 
    public int dmg = 10;
    public float wait;
    private float currentWait;
    private bool shot;
    public float velocity = 0.0f;
    public float acceleration = 0.1f;
    int VelocityHash;
    private bool isDead;
    //public bool doorReady;

    public Animator animator1;
    
    public GameObject Bullet;
    public GameObject BulletSpawnPoint;
    private Transform bulletSpawned;
    public CapsuleCollider enemyCollider;

    // Update is called once per frame

    Transform target;
    NavMeshAgent agent;
    
    void Start (){
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        BulletSpawnPoint = GameObject.Find("BulletSpawnPoint");
        enemyCollider = GetComponent<CapsuleCollider>();
        VelocityHash = Animator.StringToHash("Velocity");
        //doorReady = false;
        isDead = false;
    }

   //Update is called once per frame
    void Update()
    {
        //Follow player
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            velocity += Time.deltaTime * acceleration;
            agent.SetDestination(target.position);
            agent.speed = 10f;
            //animator1.SetFloat("Speed", 2f);
        }
        else
        {
            //agent.speed = 0f;
            //animator1.SetFloat("Speed", 0f);
        }

        animator1.SetFloat(VelocityHash, velocity);

        //If player is within distance, and ready to shoot, then shoot
        if(distance <= lookRadius && currentWait == 0)
        {
            Shoot();
        }

        //If enemy has shot, wait a sec before shooting again
        if (shot && currentWait < wait)
        {
            currentWait += 1 * Time.deltaTime;
        }
        if(currentWait >= wait)
        {
            currentWait = 0;
        }

        if (health <= 0f) {
            isDead = true;
            Die();
       }

    }

    public void Shoot()
    {
        shot = true;
        animator1.SetBool("Shoot", true);
        bulletSpawned = Instantiate(Bullet.transform, BulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;
    }

    void Die (){
        if(isDead == true) {
            lookRadius = 0;
            animator1.SetBool("Dead", true);
            enemyCollider.enabled = false;
            //doorReady = true;
            doorOpenScript.kills += 1;
            health = 1f;
            isDead = false;
        }
    }

    //Draws a sphere around the enemy model, for detecting if the player is within it
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos. DrawWireSphere(transform.position, lookRadius);    
    }
}