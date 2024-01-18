using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask selectedLayerMask;
    private Rigidbody2D playerRB;
    private Transform checkGround;

    [SerializeField]
    private float moveSpeed;
    private float inputX;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded;


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        checkGround = GameObject.Find("CheckGround").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckDirection();
    }

    private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        playerRB.velocity = new Vector2(inputX, playerRB.velocity.y);
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, 0.20f, selectedLayerMask);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
    }

    private void CheckDirection()
    {
        if(playerRB.velocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if (playerRB.velocity.x > 0)
            transform.localScale = Vector3.one;
    }
}
