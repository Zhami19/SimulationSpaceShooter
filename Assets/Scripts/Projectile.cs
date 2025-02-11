using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _projectileSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * _projectileSpeed * Time.deltaTime);
        destroyProjectile();
    }


    private void destroyProjectile()
    {
        if (transform.position.y >= 6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            FindFirstObjectByType<GameManager>().Score += 1;
        }
        else if (collision.tag == "Faster Enemy")
        {
            Destroy(collision.gameObject);
            FindFirstObjectByType<GameManager>().Score += 3;
        }
    }
}
