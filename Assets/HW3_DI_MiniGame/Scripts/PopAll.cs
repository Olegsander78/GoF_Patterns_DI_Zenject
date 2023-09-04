using System.Collections.Generic;

public class PopAll : IWinCondition
{
    public bool HasWon(List<Ball> balls)
    {
        return balls.TrueForAll(ball => ball.IsPopped);
    }
}