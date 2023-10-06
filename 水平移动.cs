using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");

      
        float horizontalVelocity = horizontalInput * moveSpeed;

      
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }
}