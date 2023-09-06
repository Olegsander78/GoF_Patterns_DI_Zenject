using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuHUD : MonoBehaviour
{
    [SerializeField] private Button _levelSelectionMenuButton;
    [SerializeField] private Button _quitButton;

    private ISceneLoadMediator _sceneLoadMediator;

    [Inject]
    private void Construct(ISceneLoadMediator sceneLoadMediator)
    {
        _sceneLoadMediator = sceneLoadMediator;
    }

    private void OnEnable()
    {
        _levelSelectionMenuButton.onClick.AddListener(OnLevelSelectionMenuClick);
        _quitButton.onClick.AddListener(OnQuitClick);
    }

    private void OnDisable()
    {
        _levelSelectionMenuButton.onClick.RemoveListener(OnLevelSelectionMenuClick);
        _quitButton.onClick.RemoveListener(OnQuitClick);
    }   

    private void OnLevelSelectionMenuClick()
    {
        _sceneLoadMediator.GoToLevelSelectionMenu();
    }

    private void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
