//using UnityEngine;
//using Zenject;

//public class EnemyFactoryInstaller : MonoInstaller
//{
//    [SerializeField] private EnemyConfig _smallConfig, _mediumConfig, _largeConfig;

//    public override void InstallBindings()
//    {
//        BindEnemiesConfig();
//    }

//    private void BindEnemiesConfig()
//    {
//        Container.Bind<EnemyConfig>().FromInstance(_smallConfig);
//        Container.Bind<EnemyConfig>().FromInstance(_mediumConfig);
//        Container.Bind<EnemyConfig>().FromInstance(_largeConfig);
//    }
//}
