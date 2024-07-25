using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public QuizUI quizUI;
    public QuestionDatabase questionDatabase;
    private List<QuestionDatabase.Question> questionList;
    private QuestionDatabase.Question currentQuestion;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private TMP_Text _gameOverScoreText;

    private void Start()
    {
        if (quizUI == null || questionDatabase == null || questionDatabase.questions.Length == 0)
        {
            return;
        }

        InitializeQuestionList();
        StartCoroutine(StartQuiz());
    }

    private void InitializeQuestionList()
    {
        questionList = new List<QuestionDatabase.Question>(questionDatabase.questions);
        Shuffle(questionList);
    }

    private IEnumerator StartQuiz()
    {
        while (questionList.Count > 0)
        {
            yield return new WaitForSeconds(1f);
            DisplayNewQuestion();
            yield return new WaitUntil(() => quizUI.IsAnswered);
            CheckAnswer(quizUI.UserAnswer);
            yield return new WaitForSeconds(1f);
        }
        _gameOverScoreText.text = $"Your score: {EndlessScoreManager.Score}";
        _scoreText.SetActive(false);
        _gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    private void DisplayNewQuestion()
    {
        currentQuestion = GetNextQuestion();
        if (currentQuestion != null)
        {
            quizUI.DisplayQuestion(currentQuestion);
        }
    }

    private void CheckAnswer(bool userAnswer)
    {
        if (currentQuestion != null)
        {
            if (userAnswer == currentQuestion.isTrue)
            {
                quizUI.HideQuestion();
                EndlessScoreManager.Score++;
            }
            else
            {
                _gameOverScoreText.text = $"Your score: {EndlessScoreManager.Score}";
                _scoreText.SetActive(false);
                _gameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private QuestionDatabase.Question GetNextQuestion()
    {
        if (questionList.Count == 0)
        {
            return null;
        }
        int index = Random.Range(0, questionList.Count);
        QuestionDatabase.Question question = questionList[index];
        questionList.RemoveAt(index);
        return question;
    }

    private void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
