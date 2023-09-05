using System;
using System.IO;
using UnityEngine;
using Zenject;

public class EnemyFactory 
{
    private const string SMALL_CONFIG = "SmallEnemyConfig";
    private const string MEDIUM_CONFIG = "MediumEnemyConfig";
    private const string LARGE_CONFIG = "LargeEnemyConfig";
    private const string CONFIGS_PATH = "EnemyConfigs";

    private EnemyConfig _small, _medium, _large;
    private DiContainer _container;
        
    public EnemyFactory(DiContainer container)
    {
        _container = container;
        Load();
    }

    public Enemy Get(EnemyType enemyType)
    {
        EnemyConfig config = GetConfig(enemyType);
        Enemy instance = _container.InstantiatePrefabForComponent<Enemy>(config.Prefab);
        instance.Initialize(config.Health, config.Speed, config.Weight);
        return instance;
    }

    private void Load()
    {
        _small = Resources.Load<EnemyConfig>(Path.Combine(CONFIGS_PATH, SMALL_CONFIG));
        _medium = Resources.Load<EnemyConfig>(Path.Combine(CONFIGS_PATH, MEDIUM_CONFIG));
        _large = Resources.Load<EnemyConfig>(Path.Combine(CONFIGS_PATH, LARGE_CONFIG));
    }

    private EnemyConfig GetConfig(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Small:
                return _small;

            case EnemyType.Medium:
                return _medium;

            case EnemyType.Large:
                return _large;

            default:
                throw new ArgumentException(nameof(enemyType));
        }
    }
}
