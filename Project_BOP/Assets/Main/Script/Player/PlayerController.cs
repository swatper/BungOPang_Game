using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 0.5f;
    public float maxSpeed = 5f;

    Rigidbody2D rigidBody;
    Animator animator;

    void Awake()
    {
        //RigidBody2D
        rigidBody = GetComponent<Rigidbody2D>();
        //Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("KeyDownSpace", true);
            animator.SetBool("KeyUpSpace", false);
            animator.SetBool("Idle", false);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("KeyDownSpace", false);
            animator.SetBool("KeyUpSpace", true);
            animator.SetBool("Idle", false);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerJump();
        }

        if (rigidBody.velocityY < 0)
        {
            PlayerLanding();
        }
    }

  
    void PlayerJump()
    {
        Vector2 worldUp = Vector2.up;
        rigidBody.AddForce(worldUp * force, ForceMode2D.Impulse);

        if (rigidBody.velocity.y > maxSpeed)
        {
            rigidBody.velocity = new Vector2(0, maxSpeed);
        }
    }

  
    void PlayerLanding()
    {
        Debug.DrawRay(rigidBody.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rigidBody.position, Vector3.down, 1, LayerMask.GetMask("platform"));

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.distance < 1f)
            {
                animator.SetBool("KeyDownSpace", false);
                animator.SetBool("KeyUpSpace", false);
                animator.SetBool("Idle", true);
            }
        }

    }
}