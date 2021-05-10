using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [SerializeField] float raycastDistance = 0.8f;
    public LayerMask[] groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;

    [SerializeField]
    bool isGround;
    bool doubleJump;

    private void Awake()
    {
        speed = PlayerData.Speed;
        jumpPower = PlayerData.JumpPower;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (GameInputs.Left)
        {
            //transform.eulerAngles = Vector3.down * 180;
            sr.flipX = true;
            transform.Translate(transform.right * -speed);
            animator.SetBool("isMoving", true);
        }
        if (GameInputs.Right)
        {
            //transform.eulerAngles = Vector3.zero;
            sr.flipX = false;
            transform.Translate(transform.right * speed);
            animator.SetBool("isMoving", true);
        }
        if (GameInputs.Down)
        {
            gameObject.layer = 9;
        }
        if (GameInputs.Jump)
        {
            if (isGround)
            {
                gameObject.layer = 10;
                GameInputs.Jump = false;
                rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            }
            else if (doubleJump)
            {
                gameObject.layer = 10;
                GameInputs.Jump = false;
                rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                doubleJump = false;
            }

        }
        if (!GameInputs.Right && !GameInputs.Left)
        {
            animator.SetBool("isMoving", false);
        }
        if (isGround)
        {
            animator.SetBool("jump", false);
            doubleJump = true;
        }
        else
        {
            animator.SetBool("jump", true);
        }
    }
    private void Update()
    {
        IsGrounded();
    }

    void IsGrounded()
    {
        Vector2 position = new Vector2(transform.position.x + boxCollider.size.x / 4, transform.position.y);
        Vector2 position2 = new Vector2(transform.position.x - boxCollider.size.x / 4, transform.position.y);
        Vector2 direction = Vector2.down;

        for (int i = 0; i < 2; i++)
        {
            RaycastHit2D hitRight = Physics2D.Raycast(position, direction, raycastDistance, groundLayer[i]);
            RaycastHit2D hitLeft = Physics2D.Raycast(position2, direction, raycastDistance, groundLayer[i]);
            if (hitRight.collider != null || hitLeft.collider != null)
            {
                isGround = true;
                return;
            }
        }

        isGround = false;

    }

}
