using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public StagesSelector currentStage;

    [SerializeField]
    GameObject _enemyPrefab;
    [SerializeField]
    GameObject _enemyParent;
    [SerializeField]
    GameObject _powerupPrefab;

    float _plainIslandXPos = 7f;    
    float _plainIslandZPos = 13f;

    [SerializeField]
    Vector3 _isleOfBookTopLeftUpperLeftClamp = new Vector3(-6f, 0.15f, 7f);
    [SerializeField]
    Vector3 _isleOfBookTopLeftLowerRightClamp = new Vector3(-2.75f, 0.15f, 0.25f);

    [SerializeField]
    Vector3 _isleOfBookTopRightUpperLeftClamp = new Vector3(3f, 0.15f, 7f);
    [SerializeField]
    Vector3 _isleOfBookTopRightLowerRightClamp = new Vector3(6f, 0.15f, 0.25f);

    [SerializeField]
    Vector3 _isleOfBookBottomUpperLeftClamp = new Vector3(-6f, -0.7f, 0.9f);
    [SerializeField]
    Vector3 _isleOfBookBottomLowerRightClamp = new Vector3(6.35f, -0.7f, -7.6f);

    [SerializeField]
    Vector3 _shrineIslandUpperLeftClamp = new Vector3(-4.7f, 0.67f, 1.8f);
    [SerializeField]
    Vector3 _shrineIslandLowerRightClamp = new Vector3(8.1f, 0.61f, -9.9f);

    float randomX;
    float randomZ;
    int _currentWave = 1;

    public enum StagesSelector
    {
        SelectionMenu,
        PlainIsland,
        IsleOfBook,
        ShrineIsland
    }


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
        if (currentStage == StagesSelector.PlainIsland)
        {
            randomX = Random.Range(-_plainIslandXPos, _plainIslandXPos);
            randomZ = Random.Range(-_plainIslandXPos, _plainIslandZPos);
        }


        if  (currentStage == StagesSelector.IsleOfBook)
        {
            int spawnSection = Random.Range(0, 3);

            switch (spawnSection)
            {
                case 0:
                    randomX = Random.Range(_isleOfBookTopLeftUpperLeftClamp.x, _isleOfBookTopLeftLowerRightClamp.x);
                    randomZ = Random.Range(_isleOfBookTopLeftUpperLeftClamp.z, _isleOfBookTopLeftLowerRightClamp.z);
                    break;
                case 1:
                    randomX = Random.Range(_isleOfBookTopRightUpperLeftClamp.x, _isleOfBookTopRightLowerRightClamp.x);
                    randomZ = Random.Range(_isleOfBookTopRightUpperLeftClamp.z, _isleOfBookTopRightLowerRightClamp.z);
                    break;
                case 2:
                    randomX = Random.Range(_isleOfBookBottomUpperLeftClamp.x, _isleOfBookBottomLowerRightClamp.x);
                    randomZ = Random.Range(_isleOfBookBottomUpperLeftClamp.z, _isleOfBookBottomLowerRightClamp.z);
                    break;
                default:
                    break;
            }
        }

        if (currentStage == StagesSelector.ShrineIsland)
        {
            randomX = Random.Range(_shrineIslandUpperLeftClamp.x, _isleOfBookBottomLowerRightClamp.x);
            randomZ = Random.Range(_shrineIslandUpperLeftClamp.z, _isleOfBookBottomLowerRightClamp.z);
        }

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
