using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRun", true);
            Debug.Log("입력됬어용!!!");
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRun", true);
            Debug.Log("입력됬어용!!!");
            
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * JumpSpeed * Time.deltaTime);
            isGrounded = false;  // 점프 후 공중에 있음
            //점프 애니 이따 추가
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
