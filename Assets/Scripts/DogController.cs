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

    void Awake()
    {
        animator = GetComponent<Animator>();   

        dog = GetComponent<Dog>();
        dog.Configure();
        
        currentSpeed = dog.Speed;
        maxSpeed = dog.Speed;
    }

    void Start()
    {

        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = dog.Speed;
        transform.Translate(Vector3.forward * Time.deltaTime * dog.Speed);

        animator.SetFloat("Speed_f", currentSpeed/ maxSpeed * 0.5f);
    }
}
