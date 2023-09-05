using UnityEngine;

public class GameplayMediator 
{
    private DefeatPanel _defeatPanel;
    private Level _level;

    public GameplayMediator(DefeatPanel defeatPanel)
    {
        _defeatPanel = defeatPanel;
    }

    ~GameplayMediator()
    {
        _level.Defeat -= OnLevelDefeat;
    }

    public void Initialize(Level level)
    {
        _level = level;
        _level.Defeat += OnLevelDefeat;
    }

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }

    private void OnLevelDefeat() => _defeatPanel.Show();
}
