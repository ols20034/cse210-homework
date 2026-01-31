public class JournalEntry
{

    private string _date;
    private string _prompt;
    private string _response;

    public string Date { get { return _date; } }
    public string Prompt { get { return _prompt; } }
    public string Response { get { return _response; } }

    public JournalEntry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }
    public void UpdateResponse(string newResponse)
    {
    _response = newResponse;
    }
    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n");
    }
}