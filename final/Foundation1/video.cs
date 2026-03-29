using System;
using System.Collections.Generic;

// Youtube video
public class Video : MediaContent
{
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
        : base(title, author, lengthInSeconds) { }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
    }
}
