using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _fasterEnemyPrefab;

    private Vector3 _enemyPosition;

    public GameObject gameManager;
    public GameManager gameManagerScript;

    Coroutine co1;
    Coroutine co2;

    private bool _hasIncreasedDifficulty = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        co1 = StartCoroutine(SpawnEnemy(3f));
        co2 = StartCoroutine(SpawnFasterEnemy(6f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasIncreasedDifficulty && FindFirstObjectByType<GameManager>().Score == 20)
        {
            _hasIncreasedDifficulty = true;

            StopCoroutine(co1);
            StopCoroutine(co2);

            StartCoroutine(SpawnEnemy(1.5f));
            StartCoroutine(SpawnFasterEnemy(3f));
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