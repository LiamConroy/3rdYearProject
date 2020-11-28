using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    // Start is called before the first frame update

    #region Singleton 

    public static PlayerLocation instance;

    void Awake(){
        instance = this;
    }

    #endregion



    public GameObject PlayerCharacter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
