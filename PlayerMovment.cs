using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed = 1.25f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("Shift", false);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 2f;
            animator.SetBool("Shift", true);
        }
        else
        {
            moveSpeed=1.25f;
            animator.SetBool("Shift", false);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
