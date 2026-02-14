public class JournalEntry
{
    private string _date;
    private string _prompt;
    private string _response;

    public JournalEntry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }

    public void UpdateResponse(string newResponse)
    {
        _response = newResponse;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n");
    }
}