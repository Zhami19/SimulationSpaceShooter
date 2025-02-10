using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private Vector3 _enemyPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy(3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy(float seconds)
    {
        while (true)
        {
            _enemyPosition = new Vector3(Random.Range(-8, 8), 6.20f, 0);
            yield return new WaitForSeconds(seconds);
            Instantiate(_enemyPrefab, _enemyPosition, Quaternion.identity);
            
        }
    }



}
//might put the while true loop in tis own function
//create multiple coroutines for different waiting times
//make sure to research how to end a coroutine