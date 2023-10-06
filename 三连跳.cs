using UnityEngine;

public class 三连跳 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 70f;
    private int n = 0;
    public int maxn = 3;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || n < maxn))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            n++;
        }

        if (isGrounded && n > 0)
        {
            n = 0;
        }
    }
}