using System.Collections.Generic;

public interface IWinCondition
{
    bool HasWon(List<Ball> balls);
}