using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemiesSpawnInstaller : MonoInstaller
{    
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;

    public override void InstallBindings()
    {
        BindEnemySpawner();
        BindEnemyCreation();
    }
    private void BindEnemySpawner()
    {   
        Container.Bind<EnemySpawner>().AsSingle();
    }

    private void BindEnemyCreation()
    {
        Container.Bind<EnemyFactory>().AsSingle();
        Container.Bind<float>().FromInstance(_spawnCooldown).WhenInjectedInto<EnemySpawner>();
        Container.Bind<List<Transform>>().FromInstance(_spawnPoints).WhenInjectedInto<EnemySpawner>();
    }    
}

