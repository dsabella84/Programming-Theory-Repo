using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float Speed {
        get { return speed;}
    }
    [SerializeField] Food dogFood;

    // ENCAPSULATION
    protected float speed;
    protected float currentSpeed;
    
    
    // Update is called once per frame
    protected void Update()
    {            
        PerformMove();
    }

    public virtual void PerformMove()
    {
        
    }
}
