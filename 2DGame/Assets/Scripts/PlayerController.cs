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
    private Animator playerAnimator;

    [SerializeField]
    private float moveSpeed;
    private float inputX;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded;
    private int IDSpeed;
    private int IDIsGrounded;


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        checkGround = GameObject.Find("CheckGround").GetComponent<Transform>();
        playerAnimator = GameObject.Find("StandupPlayer").GetComponent<Animator>();
        IDSpeed = Animator.StringToHash("speed");
        IDIsGrounded = Animator.StringToHash("isGrounded");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckDirection();
        SetAnimations();
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

    private void SetAnimations()
    {
        playerAnimator.SetBool(IDIsGrounded, isGrounded);
        playerAnimator.SetFloat(IDSpeed, Mathf.Abs(inputX));
    }
}
