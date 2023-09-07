using System;

public class LevelLoadingData 
{
    public int Level
    {
        get => _level;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "The level number cannot be negative.");

            _level = value;
        }
    }

    public ConditionGameTypes ConditionGame { get => _conditionGame; set => _conditionGame = value; }

    private int _level;
    private ConditionGameTypes _conditionGame;

    public LevelLoadingData(ConditionGameTypes conditionGame)
    {
        _conditionGame = conditionGame;
    }   
}
