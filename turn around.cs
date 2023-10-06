using UnityEngine;

public class TURNAROUND : MonoBehaviour
{
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0 && transform.localScale.x < 0) 
        {
            FlipHorizontal();
        }
        else if (horizontalInput < 0 && transform.localScale.x > 0)
        {
            FlipHorizontal();
        }
    }

    void FlipHorizontal()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; 
        transform.localScale = theScale;
    }
}