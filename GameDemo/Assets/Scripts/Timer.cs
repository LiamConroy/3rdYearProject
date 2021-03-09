using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timeStart;
    public Text textBox;
    public static bool timerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if(timerActive){
            timerActive = false;
            timeStart = 0;
        }

        textBox.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive){
        timeStart += Time.deltaTime;
        textBox.text = timeStart.ToString("F2");
        }
    }

    void OnTriggerEnter(Collider other){

        Debug.Log(timerActive);

        if (other.transform.CompareTag("Player")){
            timerActive = !timerActive;
        }
    }

}
