using System.Collections;
using System.Globalization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _fasterEnemyPrefab;

    private Vector3 _enemyPosition;

    public GameObject gameManager;
    public GameManager gameManagerScript;

    private float _timeLeft = 20f;

    Coroutine co1;
    Coroutine co2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        co1 = StartCoroutine(SpawnEnemy(5f));
        co2 = StartCoroutine(SpawnFasterEnemy(10f));


        while (_timeLeft >= 0f)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 1f)
            {
                _timeLeft = 0f;
            }
            Debug.Log(_timeLeft);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeLeft == 0f)
        {
            StopCoroutine(co1);
            StopCoroutine(co2);

            StartCoroutine(SpawnEnemy(3f));
            StartCoroutine(SpawnFasterEnemy(6f));
        }
    }

    private IEnumerator SpawnEnemy(float seconds)
    {
        Debug.Log("co1 started");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        while (gameManagerScript.isGameOver == false)
        {
            _enemyPosition = new Vector3(Random.Range(-8, 8), 6.20f, 0);
            yield return new WaitForSeconds(seconds);
            Instantiate(_enemyPrefab, _enemyPosition, Quaternion.identity);
            
        }
    }

    private IEnumerator SpawnFasterEnemy(float seconds)
    {
        Debug.Log("co2 started");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        while (gameManagerScript.isGameOver == false)
        {
            _enemyPosition = new Vector3(Random.Range(-8, 8), 6.20f, 0);
            yield return new WaitForSeconds(seconds);
            Instantiate(_fasterEnemyPrefab, _enemyPosition, Quaternion.identity);

        }
    }

}
//might put the while true loop in tis own function
//create multiple coroutines for different waiting times
//make sure to research how to end a coroutine