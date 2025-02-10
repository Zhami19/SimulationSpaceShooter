using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 5 * Time.deltaTime);
        destroyProjectile();
    }

    private void destroyProjectile()
    {
        if (transform.position.y >= 6)
        {
            Destroy(gameObject);
        }
    }
}
