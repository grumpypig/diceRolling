using UnityEngine;
using System.Collections;

[System.Serializable]
public class QuizSet {

    public string[] questions;
    public int rightOne;
    public string title;

    public QuizSet(string[] allQuestions, int answer, string header)
    {
        questions = new string[allQuestions.Length];
        for (int i = 0; i < questions.Length; i++)
        {
            questions[i] = allQuestions[i];
        }
        title = header;
    }
}
