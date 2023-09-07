using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private int _redBallsCount;
    [SerializeField] private int _whiteBallsCount;
    [SerializeField] private int _greenBallsCount;
    [SerializeField] private Transform _parent;
    [SerializeField] private PositionGenerator _positionGenerator;
    public List<Ball> Balls { get { return _balls; } }

    private List<Ball> _balls = new List<Ball>();

    public void SpawnBalls()
    {
        for (int i = 0; i < _redBallsCount; i++)
        {
            SpawnBall(ColorTypes.Red);
        }
        for (int i = 0; i < _whiteBallsCount; i++)
        {
            SpawnBall(ColorTypes.White);
        }
        for (int i = 0; i < _greenBallsCount; i++)
        {
            SpawnBall(ColorTypes.Green);
        }
    }

    private void SpawnBall(ColorTypes color)
    {
        var position = _positionGenerator.GetPosition();
        var ballObject = Instantiate(_ballPrefab, position, Quaternion.identity, _parent);
        ballObject.SetColor(color);
        _balls.Add(ballObject);
    }
}