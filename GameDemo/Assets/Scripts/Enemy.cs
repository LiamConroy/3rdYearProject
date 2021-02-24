
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
    }

   //Update is called once per frame
    void Update()
    {
        //Follow player
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.speed = 8f;
            animator1.SetBool("Sprint", true);
            print("Sprint");
            agent.SetDestination(target.position);
        }
        else
        {
            animator1.SetBool("Sprint", false);
            agent.speed = 0f;
            //StartCoroutine(stopWalking());
        }

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
          Die();
       }
    }


    //checks if the enemy is colliding with the player, if true deal damage to the player
  //void OnTriggerStay(Collider other){
   //   PlayerMovement PlayerCharacter = other.GetComponent<PlayerMovement>();
   //  if (PlayerCharacter != null){
    //      PlayerCharacter.playerHurt(dmg);
     // }
  //}

 
//grabs the players(target) position and rotates the model to face the player
//void FaceTarget (){
      //  Vector3 direction = (target.position - transform.position).normalized;
      //  Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
       // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 15f);
 //   }
    

    //Enemy takes damage when hit by player's raycast
    //public void TakeDamage (float amount)
    // {
    //     health -= amount;
    //    if (health <= 0f) {
    //       Die();
    //    }
    // }

    public void Shoot()
    {
        shot = true;

        bulletSpawned = Instantiate(Bullet.transform, BulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;
    }


    void Die (){
        lookRadius = 0;
        animator1.SetBool("Dead", true);
        enemyCollider.enabled = false;
    }

    //Draws a sphere around the enemy model, for detecting if the player is within it
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos. DrawWireSphere(transform.position, lookRadius);    
    }
}