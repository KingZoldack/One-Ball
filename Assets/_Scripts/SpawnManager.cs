using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab;
    [SerializeField]
    GameObject _enemyParent;
    [SerializeField]
    GameObject _powerupPrefab;

    float xPos = 7f;    
    float zPos = 13f;
    int _currentWave = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNumberOfEnemies(_currentWave);
        Instantiate(_powerupPrefab, CalculateRandomPos(), _powerupPrefab.transform.rotation);
    }

    private void SpawnNumberOfEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemy =Instantiate(_enemyPrefab, CalculateRandomPos(), _enemyPrefab.transform.rotation);
            enemy.transform.parent = _enemyParent.transform;
        }
    }

    private Vector3 CalculateRandomPos()
    {
        float randomX = Random.Range(-xPos, xPos);
        float randomZ = Random.Range(-xPos, zPos);

        Vector3 randomPos = new Vector3(randomX, 0.15f, randomZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        int _enemyCount = FindObjectsOfType<Enemy>().Length;
        if (_enemyCount == 0)
        {
            if(GameObject.FindGameObjectsWithTag("Powerup").Length == 0)
               Instantiate(_powerupPrefab, CalculateRandomPos(), _powerupPrefab.transform.rotation);

            _currentWave++;
            SpawnNumberOfEnemies(_currentWave);
        }
    }
}
