using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private int _redBallsCount;
    [SerializeField] private int _whiteBallsCount;
    [SerializeField] private int _greenBallsCount;
    [SerializeField] private Transform _parent;
        
    public List<Ball> Balls { get { return _balls; } }

    private List<Ball> _balls = new List<Ball>();

    public void SpawnBalls()
    {
        for (int i = 0; i < _redBallsCount; i++)
        {
            SpawnBall(ColorType.Red);
        }
        for (int i = 0; i < _whiteBallsCount; i++)
        {
            SpawnBall(ColorType.White);
        }
        for (int i = 0; i < _greenBallsCount; i++)
        {
            SpawnBall(ColorType.Green);
        }
    }

    private void SpawnBall(ColorType color)
    {
        var position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        var ballObject = Instantiate(_ballPrefab, position, Quaternion.identity, _parent);
        ballObject.SetColor(color);
        _balls.Add(ballObject);
    }
}