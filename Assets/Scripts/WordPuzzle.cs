using UnityEngine;
using UnityEngine.UI;

public class WordPuzzle : PuzzleBase
{
    public Text display;
    public InputField input;

    string correct;

    void Start()
    {
        StartPuzzle();
    }
    public override void StartPuzzle()
    {
        string[] words = { "summer", "school", "teacher" };
        correct = words[Random.Range(0, words.Length)];

        display.text = Reverse(correct);

        input.onEndEdit.AddListener(Check);
    }

    void Check(string val)
    {
        if (val.ToLower() == correct)
            Complete(100);
        else
        {
            Fail(10);
            input.text = "";
        }
    }

    string Reverse(string s)
    {
        char[] c = s.ToCharArray();
        System.Array.Reverse(c);
        return new string(c);
    }
}