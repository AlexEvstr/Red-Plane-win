using System.Collections;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public QuizUI quizUI;
    public QuestionDatabase questionDatabase;
    private int currentQuestionIndex = -1;
    [SerializeField] private GameObject _gameOver;

    private void Start()
    {
        if (quizUI == null)
        {
            return;
        }
        if (questionDatabase == null)
        {
            return;
        }
        else if (questionDatabase.questions.Length == 0)
        {
            return;
        }

        StartCoroutine(StartQuiz());
    }

    private IEnumerator StartQuiz()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            DisplayNewQuestion();
            yield return new WaitUntil(() => quizUI.IsAnswered);
            CheckAnswer(quizUI.UserAnswer);
            yield return new WaitForSeconds(1f);
        }
    }

    private void DisplayNewQuestion()
    {
        QuestionDatabase.Question question = GetNextQuestion();
        if (question != null)
        {
            quizUI.DisplayQuestion(question);
        }
    }

    private void CheckAnswer(bool userAnswer)
    {
        if (currentQuestionIndex >= 0 && currentQuestionIndex < questionDatabase.questions.Length)
        {
            QuestionDatabase.Question currentQuestion = questionDatabase.questions[currentQuestionIndex];
            if (userAnswer == currentQuestion.isTrue)
            {
                quizUI.HideQuestion();
                EndlessScoreManager.Score++;
            }
            else
            {
                Time.timeScale = 0;
                _gameOver.SetActive(true);
            }
        }
    }

    private QuestionDatabase.Question GetNextQuestion()
    {
        if (questionDatabase.questions.Length == 0)
        {
            return null;
        }
        currentQuestionIndex = (currentQuestionIndex + 1) % questionDatabase.questions.Length;
        return questionDatabase.questions[currentQuestionIndex];
    }
}
