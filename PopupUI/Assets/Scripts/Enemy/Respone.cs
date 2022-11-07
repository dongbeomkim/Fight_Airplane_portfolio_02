using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respone : MonoBehaviour
{

    public Enemy respone;
   
    void Start()
    {
        InvokeRepeating("Produce", 3f, 3f);
    }

    void Produce()
    {
        Instantiate(respone, transform.position + new Vector3(0,1f,0), Quaternion.identity);
    }


    void Update()
    {
        
    }
}
