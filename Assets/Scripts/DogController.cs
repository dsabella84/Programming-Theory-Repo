using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float currentSpeed;
    [SerializeField] float maxSpeed;
    private Dog dog;
    private bool isMoving;

    void Start()
    {
        dog = GetComponent<Dog>();
        animator = GetComponent<Animator>();   
         
        isMoving = false;
        currentSpeed = dog.Speed;
        maxSpeed = dog.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = dog.Speed;
        transform.Translate(Vector3.forward * Time.deltaTime * dog.Speed);

        animator.SetFloat("Speed_f", currentSpeed/ maxSpeed * 0.5f);
    }
}
