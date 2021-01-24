
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
    
    // Update is called once per frame

    Transform target;
    NavMeshAgent agent;
    
    
    void Start (){
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

   //Update is called once per frame
    void Update()
    {
        //Follow player
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.speed = 2f;
            //animator1.SetBool("isRunning", true);
            agent.SetDestination(target.position);
        }
        else
        {
            //animator1.SetBool("isRunning", false);
            agent.speed = 0;
            //StartCoroutine(stopWalking());
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
    

    //allows the player to do damage to the enemy, when  its hit by a raycast
    public void TakeDamage (float amount)
    {
        health -= amount;
       if (health <= 0f) {
          Die();
       }
    }


    void Die (){
       gameObject.SetActive(false);
    }

//draws a sphere around the enemy model, for detecting if the player is within it
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos. DrawWireSphere(transform.position, lookRadius);    
    }

}


