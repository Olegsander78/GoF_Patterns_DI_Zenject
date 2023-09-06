using Zenject;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlobalMiniGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLoader();
        
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

    private void BindLoader()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoadMediator>().AsSingle();
    }

    private void BindRoutine()
    {
        //Container.Bind<CoroutineRunner_Zenject>().AsSingle();
        Container.Bind<CoroutineRunner>().AsSingle();
    }
}
