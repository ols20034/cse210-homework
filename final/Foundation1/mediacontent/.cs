// Abstract base class for media content
public abstract class MediaContent
{
    public string Title { get; protected set; }
    public string Author { get; protected set; }
    public int LengthInSeconds { get; protected set; }

    public MediaContent(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public abstract void DisplayInfo();
}