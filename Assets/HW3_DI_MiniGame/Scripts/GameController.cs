using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public Action OnEndedGame;
    public Action<string> OnSelectedCondition;
    //public event Action OnButtonConditionClicked;

    [SerializeField] private BallSpawner _ballSpawner;
    public ColorTypes ColorToPop { get => _colorToPop;}
    
    private ColorTypes _colorToPop;

    private IWinCondition _winConditionStrategy;

    private LevelLoadingData _levelLoadingData;

    [Inject]
    private void Construct(LevelLoadingData levelLoadingData)
    {
        _levelLoadingData = levelLoadingData;
    }

    private void Start()
    {
        Init();        
    }    

    private void Init()
    {
        switch (_levelLoadingData.ConditionGame)
        {
            case ConditionGameTypes.POP_ALL:
                SelectPopAllStrategy();
                break;
            case ConditionGameTypes.POP_ONE_RANDOM_COLOR:
                SelectPopOneColorStrategy();
                break;
            default:
                throw new ArgumentException(nameof(_levelLoadingData.ConditionGame), " not found");
        }
    }

    private void SelectPopAllStrategy()
    {
        _winConditionStrategy = new PopAll();

        OnSelectedCondition?.Invoke($"Pop all the balloons to win!");

        _ballSpawner.SpawnBalls();

        SuscribeBallsOnPuped();
    }

    private void SelectPopOneColorStrategy()
    {
        _colorToPop = GetRandomColorType();
        _winConditionStrategy = new PopOneColor(_colorToPop);

        OnSelectedCondition?.Invoke($"To win, pop all the balls of color - {_colorToPop}");

        _ballSpawner.SpawnBalls();

        SuscribeBallsOnPuped();
    }

    private void CheckWinCondition()
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

    private ColorTypes GetRandomColorType()
    {
        var colorTypes = (ColorTypes[])Enum.GetValues(typeof(ColorTypes));
        int randomIndex = Random.Range(0, colorTypes.Length);
        return colorTypes[randomIndex];
    }

    private void OnDisable()
    {
        foreach (var ball in _ballSpawner.Balls)
        {
            ball.OnPuped -= CheckWinCondition;
        }
    }
}