using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float speed;
    [SerializeField] Food activeFoodItem = null;
    [SerializeField] Transform handLocation;
    
    private float xRange = 20;
    private bool isThrowing = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();            
    }

    // Update is called once per frame
    void Update()
    {
        if (!isThrowing)
        { 
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput > 0)
                transform.forward = new Vector3(0, 0, 1);
            else if (horizontalInput < 0)
                transform.forward = new Vector3(0, 0, -1);

            // Check for left and right bounds
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed * Mathf.Abs(horizontalInput));
                animator.SetFloat("Speed_f", speed * Mathf.Abs(horizontalInput));
            }

            if (Input.GetKeyDown(KeyCode.Space) && activeFoodItem != null)
            {
                isThrowing = true;

                StartCoroutine(ThrowFood());
            }
        }
        
    }

    private IEnumerator ThrowFood()
    {
        transform.forward = new Vector3(-1, 0, 0);
        animator.SetFloat("Speed_f", 0);
        animator.SetInteger("Animation_int", 10);

        yield return new WaitForSeconds(0.5f);
        animator.SetInteger("Animation_int", 0);

        isThrowing = false;
    }

    public void ThrowItem()
    {
        Debug.Log("Throw Item");

        this.activeFoodItem.gameObject.SetActive(true);
        this.activeFoodItem.transform.position = this.gameObject.transform.position;

        this.activeFoodItem.transform.forward = new Vector3(-1, 0, 0);
        this.activeFoodItem.GetComponent<MoveForward>().enabled = true;
    }

    public void SetActiveFood(Food food)
    {
        if (this.activeFoodItem == null)
        {
            this.activeFoodItem = food;
            this.activeFoodItem.gameObject.SetActive(false);
        }
    }    

    void AimTowardMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity))
        {
            var _direction = hitInfo.point - transform.position;
            _direction.y = 0f;
            _direction.Normalize();
            transform.forward = _direction;
        }
    }
}
