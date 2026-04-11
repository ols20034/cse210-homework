using System;
using System.Collections.Generic;

public class Video
{
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
    }

    public string GetTitle()       { return title; }
    public string GetAuthor()      { return author; }
    public int GetLength()         { return lengthInSeconds; }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"\nTitle: {GetTitle()}");
        Console.WriteLine($"Author: {GetAuthor()}");
        Console.WriteLine($"Length: {GetLength()} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
    }
}