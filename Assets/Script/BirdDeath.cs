using UnityEngine;

public class BirdDeath : MonoBehaviour
{
    [Header("Death Boundary")]
    public float minY = -6f;
    public float maxY = 6f;

    private bool isDead = false;

    void Update()
    {
        if (transform.position.y < minY ||
            transform.position.y > maxY)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;

        Debug.Log("Bird is Dead!");

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        GameOverManager.instance.ShowGameOver();
    }
}