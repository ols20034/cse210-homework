using System;
using System.Collections.Generic;

class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitWords = text.Split(' ');
        for (int i = 0; i < splitWords.Length; i++)
        {
            _words.Add(new Word(splitWords[i]));
        }
    }

    public ScriptureReference GetReference()
    {
        return _reference;
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();

        List<Word> visibleWords = new List<Word>();
        for (int i = 0; i < _words.Count; i++)
        {
            Word w = _words[i];

            // FIXED: call IsHidden() as a method
            if (!w.IsHidden())
            {
                visibleWords.Add(w);
            }
        }

        if (visibleWords.Count == 0)
        {
            return;
        }

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            Word wordToHide = visibleWords[index];
            wordToHide.Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public override string ToString()
    {
        return $"{_reference}\n" + string.Join(" ", _words);
    }

    public bool AllWordsHidden()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            Word word = _words[i];

            // FIXED: call IsHidden() as a method
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}