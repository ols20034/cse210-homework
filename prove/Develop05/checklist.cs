class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonus = bonus;
    }

    public override string GetGoalType()
    {
        return "Checklist";
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _currentCount++;

        if (_currentCount == _targetCount)
        {
            _isComplete = true;
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public int GetProgress()
    {
        return _currentCount;
    }

    public int GetTarget()
    {
        return _targetCount;
    }

    public int GetBonus()
    {
        return _bonus;
    }
}