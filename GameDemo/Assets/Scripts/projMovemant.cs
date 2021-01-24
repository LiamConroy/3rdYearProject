using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projMovemant : MonoBehaviour
{
    
    public float tracerSpeed = 5000f;

    void Update()
    {
        transform.Translate(Vector3.forward * tracerSpeed * Time.deltaTime);
    }
}
