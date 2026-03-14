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

    public override string GetGoalType() => "Checklist";

    public override int RecordEvent()
    {
        if (_isComplete) return 0;

        _currentCount++;

        // Final completion → award points + bonus
        if (_currentCount == _targetCount)
        {
            _isComplete = true;
            return GetPoints() + _bonus;
        }

        // Partial progress → award normal points
        return GetPoints();
    }

    public int GetProgress() => _currentCount;
    public int GetTarget() => _targetCount;
    public int GetBonus() => _bonus;
}