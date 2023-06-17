using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private float _reload;
    [SerializeField] private float _countEnemy;

    private Transform[] _spawnPoints;

    private int _currentSpawn = 0;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnZone.childCount];

        for (int i = 0;  i < _spawnZone.childCount; i++)
        {
            _spawnPoints[i] = _spawnZone.GetChild(i);
        }

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var waitForSeconds = new WaitForSeconds(_reload);

        while (_currentSpawn <= _countEnemy)
        {
            int chooseSpawnPoint = Random.RandomRange(0, _spawnPoints.Length);

            Instantiate(_enemy, _spawnPoints[chooseSpawnPoint].position, Quaternion.identity);
            
            _currentSpawn++;

            yield return waitForSeconds;
        }
    }
}
