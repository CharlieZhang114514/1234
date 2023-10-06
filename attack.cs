using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public float attackRange = 0.5f;
    public int meleeDamage = 100;
    public LayerMask enemy;

   
    public GameObject FireBall;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFire = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + 1f / fireRate;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            MeleeAttack();
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(FireBall, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
        bulletScript.SetDirection(Mathf.Sign(transform.localScale.x));
    }

    void MeleeAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemy);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            enemyCollider.GetComponent<EnemyHealth>().TakeDamage(meleeDamage);
        }
    }
}