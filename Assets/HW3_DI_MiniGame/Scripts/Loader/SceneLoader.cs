using System;

public class SceneLoader : ISimpleSceneLoader, ILevelLoader
{
    private ZenjectSceneLoaderWrapper _loader;

    public SceneLoader(ZenjectSceneLoaderWrapper loader)
    {
        _loader = loader;
    }

    public void Load(SceneID sceneID)
    {
        if (sceneID == SceneID.GAMEPLAY_LEVEL)
            throw new ArgumentException($"{SceneID.GAMEPLAY_LEVEL} can't be strted without configuration.");

        _loader.Load(null, (int)sceneID);
    }

    public void Load(LevelLoadingData levelLoadingData)
    {
        _loader.Load(container =>
        {
            container.BindInstance(levelLoadingData).WhenInjectedInto<GameplaySceneInstaller>();
        }, (int)SceneID.GAMEPLAY_LEVEL);
    }
}
