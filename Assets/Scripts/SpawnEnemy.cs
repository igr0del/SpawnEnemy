using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private float _reload;
    [SerializeField] private float _countEnemy;

    private Transform[] _spawnPoints;

    private int _countSpawn = 0;

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

        while (_countSpawn <= _countEnemy)
        {
            int chooseSpawnPoint = Random.RandomRange(0, _spawnPoints.Length);

            Instantiate(_enemy, _spawnPoints[chooseSpawnPoint].position, Quaternion.identity);
            
            _countSpawn++;

            yield return waitForSeconds;
        }
    }
}
