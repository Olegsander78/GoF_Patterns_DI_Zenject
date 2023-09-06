using Zenject;

public class SceneLoadMediator : ISceneLoadMediator
{
    private ISimpleSceneLoader _simpleSceneLoader;
    private ILevelLoader _levelLoader;

    private LevelLoadingData _startLevelLoadingData;

    [Inject]
    private void Construct(ISimpleSceneLoader simpleSceneLoader, ILevelLoader levelLoader)
    {
        _simpleSceneLoader = simpleSceneLoader;
        _levelLoader = levelLoader;
    }

    public void GoToGamePlayLevel(LevelLoadingData levelLoadingData)
    {
        _startLevelLoadingData = levelLoadingData;
        _levelLoader.Load(levelLoadingData);
    }

    public void GoToLevelSelectionMenu()
    {
        _simpleSceneLoader.Load(SceneID.LEVEL_SELECTION);
    }

    public void GoToMainMenu()
    {
        _simpleSceneLoader.Load(SceneID.MAIN_MENU);
    }

    public void ResetGamePlayLevel()
    {
        _levelLoader.Load(_startLevelLoadingData);
    }
}
