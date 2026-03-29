public class Running : Activity
{
    private double distance; // in miles

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
}