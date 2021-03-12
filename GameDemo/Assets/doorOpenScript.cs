using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpenScript : MonoBehaviour
{
    public static int kills;
    public Animator animatorDoorTrigger;

    // Start is called before the first frame update
    void Start()
    {
        kills = 0;
        animatorDoorTrigger = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug
        print(kills);

        if(kills == 2) {
            animatorDoorTrigger.SetTrigger("Active");
        }
        //GameObject.Find("EnemyRobot").GetComponent<Enemy>().doorReady == true
    }
}
