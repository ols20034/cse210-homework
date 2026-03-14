class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override string GetGoalType() => "Eternal";

    public override int RecordEvent()
    {
        return GetPoints(); // never completes
    }
}