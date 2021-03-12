using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpenScript : MonoBehaviour
{
    public Animator animatorDoorTrigger;

    // Start is called before the first frame update
    void Start()
    {
        animatorDoorTrigger = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("EnemyRobot").GetComponent<Enemy>().doorReady == true) {
            animatorDoorTrigger.SetTrigger("Active");
        }
    }
}
