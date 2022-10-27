using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public static event Action<Food> OnFoodEaten;

    [SerializeField] float nourishment;
    [SerializeField] int scoreValue; 

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

    public int GetScoreValue()
    {
        return scoreValue;
    }

    public void ItemEaten()
    {
        Debug.Log("Item Eaten");
        OnFoodEaten?.Invoke(this);
    }
}
