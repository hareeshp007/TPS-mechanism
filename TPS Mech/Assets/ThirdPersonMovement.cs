using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController PlayerController;
    public Transform Camera;
    public Animator PlayerAnimator;
    public Transform GroundCheck;
    public LayerMask GroundMask;
    [Header("Movement")]
    [SerializeField]
    private float speed = 6f;
    [SerializeField]
    private float horizontal;
    [SerializeField]
    private float vertical;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private Vector3 Movedirection;
    [SerializeField]
    private float targetAngle;
    [SerializeField]
    private float turnTime=0.1f;
    [SerializeField]
    private float angleRotation;
    private float turnSmoothVelocity;
    [Header("Jump")]
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private float minYVelocity = -10f;
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private int jumpHeignt=5;
    [SerializeField]
    private float jumbVariable=-2f;
    [SerializeField]
    private float gravity=-10f;

    // Update is called once per frame
    void Update()
    {
        inputHandle();
        if(direction.magnitude > 0 )
        {
            tPMovement();
        }
        setAnimationParameters();
        checks();
        PhysicsExternal();
    }

    private void PhysicsExternal()
    {
        if (velocity.y > minYVelocity)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = jumbVariable;
        }
        PlayerController.Move(velocity * Time.deltaTime);
    }

    private void checks()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, GroundMask);

        
    }

    private void tPMovement()
    {
        targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
        angleRotation =Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,turnTime);
        transform.rotation = Quaternion.Euler(0f, angleRotation, 0f);

        Movedirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        PlayerController.Move(Movedirection.normalized * speed * Time.deltaTime);
        
    }

    private void setAnimationParameters()
    {
        PlayerAnimator.SetFloat("speed", direction.magnitude);
        PlayerAnimator.SetBool("isGrounded", isGrounded);
    }

    private void inputHandle()
    {
         horizontal = Input.GetAxisRaw("Horizontal");
         vertical = Input.GetAxisRaw("Vertical");
         direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            PlayerAnimator.SetTrigger("Jump");
            Jump();
        }
       
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeignt * jumbVariable * gravity);
    }
}
