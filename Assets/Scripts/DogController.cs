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
        isEating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEating)
        {
            currentSpeed = dog.Speed;
            transform.Translate(Vector3.forward * Time.deltaTime * dog.Speed);

            animator.SetFloat("Speed_f", currentSpeed / maxSpeed * 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            other.GetComponent<MoveForward>().enabled = false;
            StartCoroutine(EatFoodItem());
            Debug.Log("Animal Fed");
        }
    }

    private IEnumerator EatFoodItem()
    {
        isEating = true;

        animator.SetFloat("Speed_f", 0);
        animator.SetBool("Eat_b", true);

        yield return new WaitForSeconds(2.0f);

        transform.forward = new Vector3(-1, 0, 0);

        animator.SetBool("Eat_b", false);
        isEating = false;
    }
}
