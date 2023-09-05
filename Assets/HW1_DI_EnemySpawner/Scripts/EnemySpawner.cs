using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner 
{
    public Action<Enemy> OnEnemySpawned;

    private float _spawnCooldown;
    private List<Transform> _spawnPoints = new List<Transform>();
    private EnemyFactory _enemyFactory;
    private Coroutine _coroutine;

    public EnemySpawner(float spawnCooldown, List<Transform> spawnPoints, EnemyFactory enemyFactory)
    {
        _spawnCooldown = spawnCooldown;
        _spawnPoints = spawnPoints;
        _enemyFactory = enemyFactory;
    }

    public void StartWork()
    {
        StopWork();

        _coroutine = CoroutineRunner.Instance.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_coroutine != null)
            CoroutineRunner.Instance.StopCoroutine(_coroutine);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            OnEnemySpawned?.Invoke(enemy);            
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
