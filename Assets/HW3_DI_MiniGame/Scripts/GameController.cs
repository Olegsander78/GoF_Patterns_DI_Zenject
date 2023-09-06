using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public Action OnEndedGame;
    public Action<string> OnSelectedCondition;
    public event Action OnButtonConditionClicked;

    [SerializeField] private BallSpawner _ballSpawner;
    public ColorType ColorToPop { get => _colorToPop;}
    
    private ColorType _colorToPop;

    private IWinCondition _winConditionStrategy;

    private void Start()
    {
        _colorToPop = GetRandomColorType();
        OnButtonConditionClicked += _ballSpawner.SpawnBalls;
    }

    private ColorType GetRandomColorType()
    {
        var colorTypes = (ColorType[])Enum.GetValues(typeof(ColorType));
        int randomIndex = Random.Range(0, colorTypes.Length);
        return colorTypes[randomIndex];
    }

    public void SelectPopAllStrategy()
    {
        _winConditionStrategy = new PopAll();

        OnSelectedCondition?.Invoke($"Pop all the balloons to win!");

        OnButtonConditionClicked?.Invoke();

        SuscribeBallsOnPuped();
    }

    public void SelectPopOneColorStrategy()
    {
        _winConditionStrategy = new PopOneColor(_colorToPop);

        OnSelectedCondition?.Invoke($"To win, pop all the balls of color - {_colorToPop}");

        OnButtonConditionClicked?.Invoke();

        SuscribeBallsOnPuped();
    }

    public void CheckWinCondition()
    {
        if (_winConditionStrategy.HasWon(_ballSpawner.Balls))
            OnEndedGame?.Invoke();
    }

    private void SuscribeBallsOnPuped()
    {
        if (_ballSpawner.Balls != null)
        {
            foreach (var ball in _ballSpawner.Balls)
            {
                ball.OnPuped += CheckWinCondition;
            }
        }
    }

    private void OnDisable()
    {
        foreach (var ball in _ballSpawner.Balls)
        {
            ball.OnPuped -= CheckWinCondition;
        }

        OnButtonConditionClicked -= _ballSpawner.SpawnBalls;
    }
}