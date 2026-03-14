abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }


    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;
    public bool IsComplete() => _isComplete;

    public abstract string GetGoalType();
    public abstract int RecordEvent(); // returns points earned
}