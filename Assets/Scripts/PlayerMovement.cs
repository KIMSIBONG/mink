using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool player1 = true;
    private float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        // 좌우 이동
        if (GetComponent<PlayerAttack>().Canmove == true)
        {
            moveSpeed = 5f;



            if (player1)
            {
                float moveInput = Input.GetAxisRaw("Horizontal");

                rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

                if (Input.GetKeyDown(KeyCode.W) && isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }
            else
            {
                float moveInput = Input.GetAxisRaw("Horizontal1");

                rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

                if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }
        }
        if (GetComponent<PlayerAttack>().Canmove == false)
        {
            moveSpeed = 0f;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥과 충돌했는지 확인
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 떨어졌는지 확인
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
