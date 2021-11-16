using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] public CharacterController controller;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection = new Vector3(0f, 0f, 1f);

    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float gravity = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckGround();
    }

    public void Move()
    {
        Jump();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(moveDirection.z > 0)
            {
                moveDirection = new Vector3(1f, 0f, 0f);
            }
            else if (moveDirection.x > 0)
            {
                moveDirection = new Vector3(0f, 0f, 1f);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }    

    private void Jump()
    {
        if (controller.isGrounded && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Grounded", false);
            moveDirection.y = jumpSpeed;
            animator.SetTrigger("Jump");
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }

    private void CheckGround()
    {
        animator.SetBool("Grounded", controller.isGrounded);
    }

    public void SetMoveSpeed(int speed)
    {
        this.moveSpeed = speed;
    }
     public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetGravity(float gravity)
    {
        this.gravity= gravity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FallCollider"))
        {
            gameManager.alive = false;
        }

        if(other.CompareTag("Collect"))
        {
            gameManager.GainScore();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Track"))
        {
            other.GetComponentInParent<Rigidbody>().useGravity = true;
            other.GetComponentInParent<TrackController>().DestroyTrack();
        }

        if(other.CompareTag("StartPlatform"))
        {
            Destroy(other.gameObject, 1f);
        }
    }
}

