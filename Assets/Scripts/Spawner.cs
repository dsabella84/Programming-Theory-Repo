using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float range = 19.0f;
    [SerializeField] List<GameObject> availableFoodItems = new List<GameObject>();
    [SerializeField] float startDelay = 1.5f;
    [SerializeField] float repeatRate = 4.0f;

    private void OnEnable()
    {
        GameManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= GameOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", startDelay, repeatRate);
    }

    void SpawnFood()
    {        
        int randomIndex = Random.Range(0, availableFoodItems.Count);
        float randomZ = Random.Range(-range, range);

        Instantiate<GameObject>(availableFoodItems[randomIndex], new Vector3(transform.position.x, transform.position.y, randomZ), availableFoodItems[randomIndex].transform.rotation, transform);
    }

    private void GameOver()
    {
        CancelInvoke();
    }

}
