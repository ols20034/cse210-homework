class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points, int targetCount)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
    }

    public override string GetGoalType() => "Checklist";

    public override int RecordEvent()
    {
        if (_isComplete) return 0;

        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            return GetPoints();
        }
        return GetPoints(); // partial progress still earns points
    }

    public int GetProgress() => _currentCount;
    public int GetTarget() => _targetCount;
}