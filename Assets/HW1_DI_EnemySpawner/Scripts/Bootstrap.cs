using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private float _totalEnemiesWeight;    

    private EnemySpawner _spawner;    
    private float _currentTotalEnemiesWeight;

    [Inject]
    private void Construct(EnemySpawner enemySpawner) => _spawner = enemySpawner;

    private void Awake()
    {
        _currentTotalEnemiesWeight = 0;

        _spawner.OnEnemySpawned += CalculateTotalEnemiesWeight;

        _spawner.StartWork();
    }

    private void OnDisable() => _spawner.OnEnemySpawned -= CalculateTotalEnemiesWeight;

    [ContextMenu("Reset Spawn")]
    public void ResetSpawn()
    {
        _currentTotalEnemiesWeight = 0;

        _spawner.StartWork();
    }

    private void CalculateTotalEnemiesWeight(Enemy enemy)
    {        
        if (_currentTotalEnemiesWeight <= _totalEnemiesWeight)
        {
            _currentTotalEnemiesWeight += enemy.Weight;
        }
        else
        {
            Destroy(enemy.gameObject);
            _spawner.StopWork();
            Debug.LogWarning($"<color=red>The total weight of the enemies has reached the maximum: {_currentTotalEnemiesWeight}, Max:{_totalEnemiesWeight}</color>");
        }
    }
}
