using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BullDog : Dog
{
    // POLYMORPHISM
    public override void Configure()
    {
        speed = 1.0f;
    }
}
