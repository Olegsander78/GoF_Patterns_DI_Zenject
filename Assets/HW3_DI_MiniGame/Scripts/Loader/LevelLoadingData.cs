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

    private int _level;

    public LevelLoadingData(int level)
    {
        Level = level;
    }   
}
