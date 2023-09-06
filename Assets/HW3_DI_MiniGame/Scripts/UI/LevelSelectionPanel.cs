using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSelectionPanel : MonoBehaviour
{
    [SerializeField] private LevelSelectionButton[] _levelSelectionButtons;
    
    private ISceneLoadMediator _sceneLoadMediator;

    [Inject]
    private void Construct(ISceneLoadMediator sceneLoadMediator)
    {
        _sceneLoadMediator = sceneLoadMediator;
    }
    
    private void OnEnable()
    {
        foreach (var levelSelectionButton in _levelSelectionButtons)
        {
            levelSelectionButton.OnClicked += OnLevelSelected;
        }
    }

    private void OnDisable()
    {
        foreach (var levelSelectionButton in _levelSelectionButtons)
        {
            levelSelectionButton.OnClicked -= OnLevelSelected;
        }
    }

    private void OnLevelSelected(int level)
    {
        _sceneLoadMediator.GoToGamePlayLevel(new LevelLoadingData(level));
    }
}