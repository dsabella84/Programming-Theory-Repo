using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float speed;
    [SerializeField] Food activeFoodItem;
    
    private float xRange = 20;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();            
    }

    // Update is called once per frame
    void Update()
    {                            
        float horizontalInput = Input.GetAxis("Horizontal");                    

        if (horizontalInput > 0)
            transform.forward = new Vector3(0,0,1);
        else if (horizontalInput < 0)
            transform.forward = new Vector3(0,0,-1);            

        // Check for left and right bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * Mathf.Abs(horizontalInput));
            animator.SetFloat("Speed_f", speed * Mathf.Abs(horizontalInput));
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
