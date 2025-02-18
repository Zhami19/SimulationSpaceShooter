using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        destroyEnemies();
    }

    void destroyEnemies()
    {
        if (transform.position.y <= -6)
        {
            Destroy(gameObject); 
            Debug.Log("Enemy has gone below border");
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            gameManager.gameOver();
        }
    }

}
