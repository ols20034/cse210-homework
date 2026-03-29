public abstract class Activity
{
    private string date;
    private int minutes;

    public Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public string GetDate() => date;
    public int GetMinutes() => minutes;

    public abstract double GetDistance(); // in miles
    public virtual double GetSpeed() => (GetDistance() / minutes) * 60;
    public virtual double GetPace() => minutes / GetDistance();

    public virtual string GetSummary()
    {
        return $"{date} {this.GetType().Name} ({minutes} min) - " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}