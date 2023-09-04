using System.Collections.Generic;

public class PopOneColor : IWinCondition
{
    private ColorType _colorToPop;

    public PopOneColor(ColorType colorToPop)
    {
        _colorToPop = colorToPop;
    }

    public bool HasWon(List<Ball> balls)
    {
        return balls.TrueForAll(ball => ball.IsPopped || ball.ColorBall != _colorToPop);
    }
}