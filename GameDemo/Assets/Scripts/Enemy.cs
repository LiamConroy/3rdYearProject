
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
        target = PlayerLocation.instance.PlayerCharacter.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update (){

        
        float distance = Vector3.Distance(target.position, transform.position);


        //checks if the target is within the sight radius, if true the model rotates to face the player
        if (distance <= lookRadius){
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance){
             FaceTarget();
            }
        }
  
    }


    //checks if the enemy is colliding with the player, if true deal damage to the player
  // void OnTriggerStay(Collider other){
   //   PlayerMovement PlayerCharacter = other.GetComponent<PlayerMovement>();
  //    if (PlayerCharacter != null){
   //        PlayerCharacter.playerHurt(dmg);
  //     }
  // }

 
//grabs the players(target) position and rotates the model to face the player
void FaceTarget (){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 15f);
    }
    

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


