using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public float MoveSpeed = 5f;
    public float JumpSpeed = 5f;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // 좌우 이동
        float moveInput = Input.GetAxis("Horizontal"); // A/D 또는 좌우 화살표 키
        rb.velocity = new Vector2(moveInput * MoveSpeed, rb.velocity.y);

        // 스프라이트 방향 및 애니메이션 설정
        if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRun", true);
        }
        else if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
            isGrounded = false;  // 점프 후 공중에 있음
            // 점프 애니메이션 설정 (추가 가능)
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿으면 점프 가능하게
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
