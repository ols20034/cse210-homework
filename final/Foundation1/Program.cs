using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videoList = new List<Video>();

        // Create videos
        Video video1 = new Video("Product Review: Chicken Buff", "Chickenmama", 320);
        Video video2 = new Video("Unboxing: Lego Lantern Fish", "Brickbuilder", 210);
        Video video3 = new Video("Product Review: Desk Fan", "Desklife", 450);

        // Add comments to video1
        video1.AddComment(new Comment("Annie", "Totally, going to give this a try for my chickens"));
        video1.AddComment(new Comment("Bob", "Looks easy to use"));
        video1.AddComment(new Comment("Bendy", "Did it help them regrow feathers?"));

        // Add comments to video2
        video2.AddComment(new Comment("Hayley", "Looks fun to do."));
        video2.AddComment(new Comment("William", "How easy is it to put together?"));
        video2.AddComment(new Comment("Pam", "Looks super creeepy, just like the real thing."));

        // Add comments to video3
        video3.AddComment(new Comment("Michelle", "Love that it uses USB-B to power, easy to use on my desk"));
        video3.AddComment(new Comment("Christy", "Very informative."));
        video3.AddComment(new Comment("Casey", "How quiet is it while on? "));

        // Add videos to list
        videoList.Add(video1);
        videoList.Add(video2);
        videoList.Add(video3);

        // Display all video info
        foreach (var video in videoList)
        {
            video.DisplayInfo();
        }
    }
} 