abstract class Shape
{
    private string _color;

//constructor to set color
    public Shape(string color)
    {
        _color = color;
    }

//getter
    public string GetColor()
    {
        return _color;
    }

//setter
    public void SetColor(string color)
    {
        _color = color;
    }

//method to be overriden by classes
    public abstract double GetArea();
}