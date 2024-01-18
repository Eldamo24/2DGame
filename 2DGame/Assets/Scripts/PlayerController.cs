using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField]
    private float moveSpeed;
    private float inputX;
    [SerializeField]
    private float jumpForce;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        playerRB.velocity = new Vector2(inputX, playerRB.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
    }
}
