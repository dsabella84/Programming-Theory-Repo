using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            Destroy(gameObject);

            // Just deactivate it
            //gameObject.SetActive(false);

        }
        else if (transform.position.x < lowerBound)
        {
            Destroy(gameObject);
        }

    }
}
