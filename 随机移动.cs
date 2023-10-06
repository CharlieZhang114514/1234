using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float moveDirection = 1f; 
    public float changeDirectionTime = 2f;  
    private float timer;

    private Vector3 originalScale;  

    private void Start()
    {
        originalScale = transform.localScale; 
    }

    private void Update()
    {
        Move();
        HandleDirectionChange();
        UpdateFacingDirection();
    }

    void Move()
    {
        transform.Translate(Vector2.right * moveDirection * moveSpeed);
    }

    void HandleDirectionChange()
    {
        timer += Time.deltaTime;

        if (timer >= changeDirectionTime)
        {
            timer = 0f;
            moveDirection = Mathf.Sign(Random.Range(-1f, 1f));
        }
    }

    void UpdateFacingDirection()
    {
        if (moveDirection > 0)
        {
            // Face right
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else
        {
            // Face left
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }
}