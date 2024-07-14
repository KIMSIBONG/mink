using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool player1 = true;
    private float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public bool facingRight1 = true;
    public bool facingRight2 = true;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
                    animator.SetBool("Jump", true);
                }

                if (Input.GetKeyDown(KeyCode.A) && isGrounded)
                {
                    
                    animator.SetBool("Walk", true);
                    
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (facingRight1)
                    {
                        Flip1();
                    }
                }
                
                if (Input.GetKeyDown(KeyCode.D) && isGrounded)
                {

                    animator.SetBool("Walk", true);
                    

                }
                if (Input.GetKeyDown(KeyCode.D))
                {

                    

                    if (!facingRight1)
                    {
                        Flip1();
                    }
                }
                if (Input.GetKeyUp(KeyCode.D) && isGrounded)
                {
                    animator.SetBool("Walk", false);
                }


            }
            else
            {
                float moveInput = Input.GetAxisRaw("Horizontal1");

                rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

                if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    animator.SetBool("Jump", true);
                }
                //걸음
                if (Input.GetKeyDown(KeyCode.RightArrow) && isGrounded)
                {

                    animator.SetBool("Walk", true);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (facingRight2)
                    {
                        Flip2();
                    }
                }
                if (Input.GetKeyUp(KeyCode.RightArrow) && isGrounded)
                {
                    animator.SetBool("Walk", false);
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow) && isGrounded)
                {

                    animator.SetBool("Walk", true);
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {

                    if (!facingRight2)
                    {
                        Flip2();
                    }
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow) && isGrounded)
                {
                    animator.SetBool("Walk", false);
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
            animator.SetBool("Jump", false);
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
    void Flip1()
    {
        facingRight1 = !facingRight1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Flip2()
    {
        facingRight2 = !facingRight2;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
