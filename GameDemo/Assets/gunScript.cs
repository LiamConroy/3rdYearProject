using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunScript : MonoBehaviour
{
   public float dmg = 10f;
   public float projSpeed = 20f;
  // public GameObject tracer;
  // private GameObject clone;
   public Camera fpsCam;
   public AudioSource m_gunSound;
   public int ammoMax;
   public int currentAmmo;
   public int ammoPool;
   public int ammoPoolMax;
   public int ammoDif;
   public float reload = 1f;
   public float ROF = 15f; 
   private bool isReloading = false;
   public Text ammoDisplay;
   public Text ammopoolDisplay;

   //public Animator animator;

   private float nextTimeToFire = 0f;

public ParticleSystem muzzleFlash;

    // Update is called once per frame
   
   void Start(){
        m_gunSound = GetComponent<AudioSource>();
        currentAmmo = ammoMax;

   } 
   
    void Update()
    {
        
        if (isReloading){
            return;
        }

        //if the player runs out of ammo, begin reload function
        if (currentAmmo <= 0){
            StartCoroutine(Reload());
            return;
        }

        //if the ammo and ammopool reach 0, prevents player from reloading/shooting
        if (ammoPool<1 && currentAmmo <1){
            return;

        }
            
        
        //fires gun in full auto, 
        if(Input.GetButton("Fire2") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/ROF;
            m_gunSound.Play();
            Shoot();
           // clone = Instantiate(tracer, gameObject.transform.position, gameObject.transform.rotation);             
            //Debug.Log(ammo);   
        }

         
         //displays ammo and ammopool to the playhers HUD
         ammoDisplay.text = currentAmmo.ToString();
        ammopoolDisplay.text = ammoPool.ToString();


        //if(Input.GetButtonDown("Fire1") && currentAmmo <30){
            
         //   StartCoroutine(Reload());
            
          //  return;
      //  }

        //Destroy(clone, 2.0f);
    }


//Casts a ray in a straight line from the player, if it hits the "Enemy" component then it deals damage to it
    void Shoot (){
        muzzleFlash.Play();

        RaycastHit hit;

        currentAmmo--;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
           // Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null){
                enemy.TakeDamage(dmg);
            }
        }
    }


//Reload begin, sets reloading to true, prevents the player from firing while reloading

    IEnumerator Reload(){
        //animator.SetBool("Reloading", true);
        isReloading = true;

        Debug.Log("Reloading");
        //stops everything else in the script from running until the reload is doen
        yield return new WaitForSeconds(reload);
//ammo difference, know how much to take away from the ammo pool
        ammoDif = ammoMax-currentAmmo;
    
    //
     if (ammoPool<=ammoDif){
            currentAmmo = currentAmmo + ammoPool;
            ammoPool = 0;
       }

    else {
         ammoPool = ammoPool-ammoDif;
         currentAmmo = currentAmmo+ammoDif;   
    }
        
       isReloading = false;
       //animator.SetBool("Reloading", false);
    }
}
