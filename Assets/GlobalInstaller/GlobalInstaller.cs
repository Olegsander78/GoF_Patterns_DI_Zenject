using Zenject;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlobalInstaller : MonoInstaller
{
    private const string SCENE_HW1_SPAWNER = "EnemySpawnerScene";
    private const string SCENE_HW2_MEDIATOR = "MediatorScene";
    private const string SCENE_HW3_MINIGAME = "LevelMiniGame";

    public override void InstallBindings()
    {
        //BindRoutine();

        //if(SystemInfo.deviceType == DeviceType.Desktop)
        //{
        //    if (SceneManager.GetActiveScene().name == SCENE_HW1_SPAWNER)
        //    {
        //        // Global bind for hw1
                
        //    }
        //    else if (SceneManager.GetActiveScene().name == SCENE_HW2_MEDIATOR)
        //    {
        //        // Global bind for hw2
        //    }
        //    else if (SceneManager.GetActiveScene().name == SCENE_HW3_MINIGAME)
        //    {
        //        // Global bind for hw3
        //    }
        //}        
    }

    private void BindRoutine()
    {
        //Container.Bind<CoroutineRunner_Zenject>().AsSingle();
        Container.Bind<CoroutineRunner>().AsSingle();
    }
}
