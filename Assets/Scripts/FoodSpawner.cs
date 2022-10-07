using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] float range = 19.0f;
    [SerializeField] List<Food> availableFoodItems = new List<Food>();
    [SerializeField] float startDelay = 1.5f;
    [SerializeField] float repeatRate = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", startDelay, repeatRate);
    }

    void SpawnFood()
    {        
        int randomIndex = Random.Range(0, availableFoodItems.Count);
        float randomZ = Random.Range(-range, range);
        Debug.Log("Random Index: " + randomIndex);

        Food foodItem = Instantiate<Food>(availableFoodItems[randomIndex], new Vector3(transform.position.x, transform.position.y, randomZ), availableFoodItems[randomIndex].transform.rotation, transform);
    }
}
