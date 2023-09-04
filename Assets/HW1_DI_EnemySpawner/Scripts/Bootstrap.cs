using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private float _totalEnemiesWeight;
    
    private float _currentTotalEnemiesWeight;

    private void Awake()
    {
        _currentTotalEnemiesWeight = 0;

        _spawner.OnEnemySpawned += CalculateTotalEnemiesWeight;

        _spawner.StartWork();


    }

    private void OnDisable()
    {
        _spawner.OnEnemySpawned -= CalculateTotalEnemiesWeight;
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
