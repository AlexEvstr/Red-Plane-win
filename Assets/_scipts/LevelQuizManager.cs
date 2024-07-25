using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelQuizManager : MonoBehaviour
{
    public QuizUI quizUI;
    public QuestionDatabase questionDatabase;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _star1;
    [SerializeField] private GameObject _star2;
    [SerializeField] private GameObject _star3;
    [SerializeField] private Image timerBar;

    private List<QuestionDatabase.Question> questionList;
    private QuestionDatabase.Question currentQuestion;
    private int currentQuestionIndex = -1;
    private int correctAnswers = 0;
    private float totalTimeSpent = 0f;
    private float questionStartTime;
    private int levelIndex;
    private const float questionTimeLimit = 15f;
    private float remainingTime;

    private void Start()
    {
        if (quizUI == null || questionDatabase == null || questionDatabase.questions.Length == 0)
        {
            return;
        }

        levelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
        InitializeQuestionList();
        StartCoroutine(StartQuiz());
    }

    private void InitializeQuestionList()
    {
        int startQuestionIndex = (levelIndex - 1) * 5;
        questionList = new List<QuestionDatabase.Question>();

        for (int i = startQuestionIndex; i < startQuestionIndex + 5 && i < questionDatabase.questions.Length; i++)
        {
            questionList.Add(questionDatabase.questions[i]);
        }
    }

    private IEnumerator StartQuiz()
    {
        while (questionList.Count > 0)
        {
            yield return new WaitForSeconds(1f);
            DisplayNewQuestion();
            questionStartTime = Time.time;
            remainingTime = questionTimeLimit;

            while (remainingTime > 0 && !quizUI.IsAnswered)
            {
                remainingTime = questionTimeLimit - (Time.time - questionStartTime);
                UpdateTimerBar(remainingTime);
                yield return null;
            }

            if (!quizUI.IsAnswered && remainingTime <= 0)
            {
                GameOver();
                yield break;
            }

            totalTimeSpent += questionTimeLimit - remainingTime;
            CheckAnswer(quizUI.UserAnswer);
            yield return new WaitForSeconds(1f);
        }
        Win();
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
                correctAnswers++;

                if (correctAnswers == 5)
                {
                    Win();
                }
            }
            else
            {
                GameOver();
            }
        }
    }

    private QuestionDatabase.Question GetNextQuestion()
    {
        if (questionList.Count == 0)
        {
            return null;
        }
        currentQuestionIndex = Random.Range(0, questionList.Count);
        QuestionDatabase.Question question = questionList[currentQuestionIndex];
        questionList.RemoveAt(currentQuestionIndex);
        return question;
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    private void Win()
    {
        _win.SetActive(true);
        Time.timeScale = 0;

        float totalElapsedTime = totalTimeSpent;
        int stars = CalculateStars(totalElapsedTime);

        if (stars >= 1) _star1.SetActive(true);
        if (stars >= 2) _star2.SetActive(true);
        if (stars == 3) _star3.SetActive(true);

        int currentStars = PlayerPrefs.GetInt("Level_" + levelIndex + "_Stars", 0);
        if (stars > currentStars)
        {
            PlayerPrefs.SetInt("Level_" + levelIndex + "_Stars", stars);
        }

        GameLevelManager.Level++;
        PlayerPrefs.SetInt("LevelIndex", GameLevelManager.Level);
        int bestLevel = PlayerPrefs.GetInt("BestLevelIndex", 1);
        if (bestLevel < GameLevelManager.Level)
        {
            PlayerPrefs.SetInt("BestLevelIndex", GameLevelManager.Level);
        }
    }

    private int CalculateStars(float totalTime)
    {
        if (totalTime < 25)
        {
            return 3;
        }
        else if (totalTime < 50)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    private void UpdateTimerBar(float timeRemaining)
    {
        timerBar.fillAmount = timeRemaining / questionTimeLimit;
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
