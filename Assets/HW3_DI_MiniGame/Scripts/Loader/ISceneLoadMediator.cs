public interface ISceneLoadMediator 
{
    void GoToMainMenu();
    void GoToLevelSelectionMenu();
    void GoToGamePlayLevel(LevelLoadingData levelLoadingData);
    void ResetGamePlayLevel();
}
