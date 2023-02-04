using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyGameObject;

    float xPos = 7f;
    float zPos = 13f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_enemyGameObject, CalculateEnemySpawnPos(), _enemyGameObject.transform.rotation);
    }

    private Vector3 CalculateEnemySpawnPos()
    {
        float randomX = Random.Range(-xPos, xPos);
        float randomZ = Random.Range(-xPos, zPos);

        Vector3 randomPos = new Vector3(randomX, 0.15f, randomZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
