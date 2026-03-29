public class Swimming : Activity
{
    private int laps;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * 50 / 1000.0 * 0.62; // meters to miles
}