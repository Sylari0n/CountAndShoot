using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] GameObject enemy01;

    Vector3 _spawnPoint;
    int randomValue;
    float _timer = 0f;

    void Update()
    {
        _spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0.3f, 6.8f)); 
        randomValue = Random.Range(5, 15);
        SpawnEnemy();

    }

    void Timer()
    {
        _timer += Time.deltaTime;
    }


    void SpawnEnemy()
    {
        Timer();
        if (_timer > randomValue)
        {
            Instantiate(enemy01, _spawnPoint, Quaternion.identity);
            _timer = 0;
        }
    }
}
