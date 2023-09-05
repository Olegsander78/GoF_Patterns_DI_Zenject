using UnityEngine;
using Zenject;

public class MediatorBootstrap : IInitializable, ITickable
{
    private GameplayMediator _gameplayMediator;
    private DefeatPanel _defeatPanel;

    private Level _level;

    public MediatorBootstrap(GameplayMediator gameplayMediator, DefeatPanel defeatPanel)
    {
        _gameplayMediator = gameplayMediator;
        _defeatPanel = defeatPanel;        
    }

    public void Initialize()
    {
        _level = new Level();

        _gameplayMediator.Initialize(_level);
        _defeatPanel.Initalize(_gameplayMediator);

        _level.Start();
    }

    public void Tick()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            _level.OnDefeat();
    }
}
