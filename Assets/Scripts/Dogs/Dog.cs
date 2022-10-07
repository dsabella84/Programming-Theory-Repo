using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float Speed {
        get { return speed;}
    }

    // ENCAPSULATION
    protected float speed;
    protected float currentSpeed;
    
    
    // Update is called once per frame
    protected void Update()
    {            
    }

    public virtual void Configure()
    {
        speed = 0;
    }
}
