using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float currentSpeed;
    [SerializeField] float maxSpeed;
    private Dog dog;
    private bool isEating = false;
    private GameManager gameManager;
    private float multiplier = 1;

    void Awake()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

        dog = GetComponent<Dog>();
        dog.Configure();
        
        currentSpeed = dog.Speed;
        maxSpeed = dog.Speed;
    }

    void Start()
    {
        isEating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEating)
        {
            currentSpeed = dog.Speed;
            transform.Translate(Vector3.forward * Time.deltaTime * dog.Speed * multiplier);

            animator.SetFloat("Speed_f", currentSpeed / maxSpeed * 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            StartCoroutine(EatFoodItem(other));
        }

        if (other.CompareTag("Escaped"))
        {
            DogEscaped();
        }
    }

    private void DogEscaped()
    {        
        gameManager.UpdateLives(1);
        GameObject.Destroy(this.gameObject);
    }

    private IEnumerator EatFoodItem(Collider other)
    {
        other.GetComponent<MoveForward>().enabled = false;

        isEating = true;

        animator.SetFloat("Speed_f", 0);
        animator.SetBool("Eat_b", true);
        other.GetComponent<Food>().ItemEaten();

        yield return new WaitForSeconds(2.0f);

        transform.forward = new Vector3(-1, 0, 0);

        animator.SetBool("Eat_b", false);
        isEating = false;
        multiplier = 2.0f;

        GameObject.Destroy(other.gameObject);
    }
}
