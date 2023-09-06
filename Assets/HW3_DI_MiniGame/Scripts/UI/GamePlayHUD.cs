using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GamePlayHUD : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private ISceneLoadMediator _sceneLoadMediator;

    [Inject]
    private void Construct(ISceneLoadMediator sceneLoadMediator)
    {
        _sceneLoadMediator = sceneLoadMediator;
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuClick);
    }

    private void OnRestartClick()
    {
        _sceneLoadMediator.ResetGamePlayLevel();
    }

    private void OnMainMenuClick()
    {
        _sceneLoadMediator.GoToMainMenu();
    }
}
