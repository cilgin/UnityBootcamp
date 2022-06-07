using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public CharacterController _controller;

    public Animator _animator;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float gravity = -9f;

    [SerializeField]
    private float jheight = 1f;

    [SerializeField]
    private Transform gorund_Check;

    [SerializeField]
    private float gorund_Distance = 0.4f;

    [SerializeField]
    private LayerMask gorund_Mask;

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(gorund_Check.position, gorund_Distance, gorund_Mask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _animator.SetFloat("Forward", z);
        _animator.SetFloat("Strafe", x);

        Vector3 move = transform.right * x + transform.forward * z;


        _controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jheight * -2f * gravity);

        }
        if(isGrounded)
        {
            _animator.SetBool("Jump", false);

        }
        else
        {
            _animator.SetBool("Jump", true);
        }
            

        

        velocity.y += gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
    }
}
