using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBtwSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private List<EnemySpawnChance> enemiesList = new List<EnemySpawnChance>();
    private float _timerBtwSpawn;

    private void Update()
    {
        if (_timerBtwSpawn >= _timeBtwSpawn)
        {
            Spawn();
        }
        else
        {
            _timerBtwSpawn += Time.deltaTime;
        }
    }

    private void Spawn()
    {
        int chance = Random.Range(0, 101);

        foreach (EnemySpawnChance enemy in enemiesList)
        {
            if (chance <= enemy.SpawnChance)
            {
                Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
                Instantiate(enemy.EnemyPrefab, spawnPosition, Quaternion.identity);
            }
        }

        _timerBtwSpawn = 0;
    }
}

[System.Serializable]
public class EnemySpawnChance
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _spawnChance;

    public GameObject EnemyPrefab { get { return _enemyPrefab; } }
    public int SpawnChance { get { return _spawnChance; } }
}
