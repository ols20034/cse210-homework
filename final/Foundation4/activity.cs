public abstract class Activity
{
    private string date;
    private int minutes;

    public Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public string GetDate()
    {
        return date;
    }

    public int GetMinutes()
    {
        return minutes;
    }

    public abstract double GetDistance();

    public virtual double GetSpeed()
    {
        return (GetDistance() / minutes) * 60;
    }

    public virtual double GetPace()
    {
        return minutes / GetDistance();
    }

    public virtual string GetSummary()
    {
        return date + " " + this.GetType().Name + " (" + minutes + " min) - " +
               "Distance: " + GetDistance().ToString("0.0") + " miles, " +
               "Speed: " + GetSpeed().ToString("0.0") + " mph, " +
               "Pace: " + GetPace().ToString("0.0") + " min per mile";
    }
}