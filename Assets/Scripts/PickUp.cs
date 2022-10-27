using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + "Ran into pickup " + this.name);

        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();

            Food food = GetComponent<Food>();

            player.SetActiveFood(food);
        }
    }

}