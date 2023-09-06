using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    private LevelLoadingData _levelLoadingData;

    public override void InstallBindings()
    {
        Container.Bind<LevelLoadingData>().FromInstance(_levelLoadingData);
    }

    [Inject]
    private void Construct(LevelLoadingData levelLoadingData)
    {
        _levelLoadingData = levelLoadingData;
        Debug.Log(levelLoadingData);
    }
}
